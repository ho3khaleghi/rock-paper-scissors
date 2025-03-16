using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Repository.Extensions;

namespace RockPaperScissors.Repository.Battle
{
    public class BestOfOneBattleRepository : BattleAbstraction, IBestOfOneBattleRepository
    {
        public BestOfOneBattleRepository(ILogger<BestOfOneBattleRepository> logger) : base(logger)
        {
            Battles = new ConcurrentDictionary<Guid, BattleDto>();
            PlayerBattles = new ConcurrentDictionary<string, ConcurrentStack<BattleDto>>();
        }

        protected override ConcurrentDictionary<Guid, BattleDto> Battles { get; }
        protected override ConcurrentDictionary<string, ConcurrentStack<BattleDto>> PlayerBattles { get; }

        protected override bool CheckWinner(BattleDto battle)
        {
            if (battle.PlayerOne.Score > 1) battle.WinnerId = battle.PlayerOneId;
            else if (battle.PlayerTwo.Score > 1) battle.WinnerId = battle.PlayerTwoId;

            return string.IsNullOrWhiteSpace(battle.WinnerId);
        }
    }
}
