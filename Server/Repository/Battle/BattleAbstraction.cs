using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Battle
{
    public abstract class BattleAbstraction(ILogger<BattleAbstraction> logger) : IBattleRepository
    {
        protected abstract ConcurrentDictionary<Guid, BattleDto> Battles { get; }
        protected abstract ConcurrentDictionary<long, ConcurrentStack<BattleDto>> UsersBattles { get; }

        public bool TryAddBattle(BattleDto battle)
        {
            if (Battles.TryAdd(battle.BattleId, battle))
            {
                UsersBattles.AddOrUpdate(battle.PlayerOneId,
                                         (playerId) =>
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
                UsersBattles.AddOrUpdate(battle.PlayerTwoId,
                                         (playerId) =>
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

                return true;
            }

            return false;
        }

        public bool TryAddPlayerChoice(Guid battleId, long playerId, PlayerChoice playerChoice)
        {
            if (!UsersBattles.TryGetValue(playerId, out var usersBattle))
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

            return true;
        }

        protected abstract void CheckWinner(BattleDto battle);
    }
}