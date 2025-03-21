using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Extensions;

namespace RockPaperScissors.Repository.Battle
{
    public class BattleRepository(ILogger<BattleRepository> logger) : IBattleRepository
    {
        private ConcurrentDictionary<Guid, BattleDto> Battles { get; } = new();
        private ConcurrentDictionary<string, ConcurrentStack<BattleDto>> PlayerBattles { get; } = new();
        private ConcurrentDictionary<Guid, Dictionary<string, PlayerChoiceDto?>?> PlayersLastChoice { get; } = new();
        private ConcurrentQueue<BattleUpdateNotificationDto> NotificationQueue { get; } = new();

        public bool TryAddBattle(BattleDto battle)
        {
            if (Battles.TryAdd(battle.BattleId, battle))
            {
                PlayersLastChoice.TryAdd(battle.BattleId, null);

                AddPlayerBattle(battle.PlayerOneId, battle);
                AddPlayerBattle(battle.PlayerTwoId, battle);

                return true;
            }

            return false;
        }

        public bool TryAddPlayerChoice(Guid battleId, string playerId, PlayerChoice playerChoice)
        {
            if (!PlayerBattles.TryGetValue(playerId, out var usersBattle))
            {
                logger.LogWarning($"Player {playerId} has no users battle. Could not add player choice.");
                return false;
            }

            if (!usersBattle.TryPeek(out var battle))
            {
                logger.LogWarning($"User {playerId} has no users battle. Could not add player choice.");
                return false;
            }

            if (battleId != battle.BattleId)
            {
                logger.LogWarning($"Battle {battleId} is not the current battle for player {playerId}. Could not add player choice.");
                return false;
            }

            if (battle.PlayerOneId == playerId) battle.PlayerOne.PlayerChoices.Enqueue(playerChoice);
            else battle.PlayerTwo.PlayerChoices.Enqueue(playerChoice);

            PlayersLastChoice.TryGetValue(battleId, out var playerChoices);
            if (playerChoices is null)
            {
                playerChoices = new()
                {
                    { playerId, new(playerId, playerChoice) }
                };

                PlayersLastChoice.TryUpdate(battleId, playerChoices, null);
            }
            else
            {
                playerChoices[playerId] = new(playerId, playerChoice);
            }

            if (playerChoices.Keys.Count() == 2)
            {
                NotificationQueue.Enqueue(new(battleId, playerChoices.Values.First()!, playerChoices.Values.Last()!));
                PlayersLastChoice.AddOrUpdate(battleId, (a) => null, (b, c) => null);
            }

            return true;
        }

        public bool TryCheckWinner(Guid battleId, out string? winnerId)
        {
            winnerId = null;

            if (!Battles.TryGetValue(battleId, out var battle))
            {
                logger.LogWarning($"Battle {battleId} does not exist. Could not calculate score.");
                return false;
            }

            if (!battle.PlayerOne.PlayerChoices.IsEmpty ||
                !battle.PlayerTwo.PlayerChoices.IsEmpty ||
                battle.PlayerOne.PlayerChoices.Count != battle.PlayerTwo.PlayerChoices.Count)
            {
                return false;
            }

            var playerOneChoices = battle.PlayerOne.PlayerChoices.ToArray();
            var playerTwoChoices = battle.PlayerTwo.PlayerChoices.ToArray();
            var playerOneScore = 0;
            var playerTwoScore = 0;

            for (var i = 0; i < playerOneChoices.Length; i++)
            {
                var playerOneWon = playerOneChoices[i].Compare(playerTwoChoices[i]);

                if (playerOneWon == null) continue;

                if (playerOneWon.Value) playerOneScore++;
                else playerTwoScore++;

                if (CheckWinner(battle))
                {
                    winnerId = battle.WinnerId;
                    battle.EndedAt = DateTime.UtcNow;
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<BattleUpdateNotificationDto?> GetPlayersLastChoice()
        {
            yield return NotificationQueue.TryDequeue(out var notification) ? notification : null;
        }

        private void AddPlayerBattle(string playerId, BattleDto battle)
        {
            PlayerBattles.AddOrUpdate(playerId,
                         (id) =>
                         {
                             var battles = new ConcurrentStack<BattleDto>();

                             battles.Push(battle);

                             return battles;
                         },
                         (key, value) =>
                         {
                             // Although concurrency is not guaranteed here, a user cannot join many battles at the same time.
                             // Therefore, concurrency can be ignored.
                             value.Push(battle);
                             return value;
                         });
        }

        private static bool CheckWinner(BattleDto battle)
        {
            if (battle.PlayerOne.Score > (int)battle.GameOption) battle.WinnerId = battle.PlayerOneId;
            else if (battle.PlayerTwo.Score > (int)battle.GameOption) battle.WinnerId = battle.PlayerTwoId;

            return string.IsNullOrWhiteSpace(battle.WinnerId);
        }
    }
}