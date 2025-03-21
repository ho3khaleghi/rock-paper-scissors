﻿using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository.Battle
{
    public class BestOfFiveBattleRepository : BattleAbstraction, IBestOfFiveBattleRepository
    {
        public BestOfFiveBattleRepository(ILogger<BestOfFiveBattleRepository> logger) : base(logger)
        {
            Battles = new();
            PlayerBattles = new();
            PlayersLastChoice = new();
        }

        protected override ConcurrentDictionary<Guid, BattleDto> Battles { get; }
        protected override ConcurrentDictionary<string, ConcurrentStack<BattleDto>> PlayerBattles { get; }
        protected override ConcurrentDictionary<Guid, Dictionary<string, PlayerChoiceDto?>?> PlayersLastChoice { get; }

        protected override bool CheckWinner(BattleDto battle)
        {
            if (battle.PlayerOne.Score > 5) battle.WinnerId = battle.PlayerOneId;
            else if (battle.PlayerTwo.Score > 5) battle.WinnerId = battle.PlayerTwoId;

            return string.IsNullOrWhiteSpace(battle.WinnerId);
        }
    }
}
