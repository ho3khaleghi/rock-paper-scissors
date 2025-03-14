using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository.Battle
{
    public class BestOfOneBattleRepository : BattleAbstraction, IBestOfOneBattleRepository
    {
        public BestOfOneBattleRepository(ILogger<BestOfOneBattleRepository> logger) : base(logger)
        {
            Battles = new ConcurrentDictionary<Guid, BattleDto>();
            UsersBattles = new ConcurrentDictionary<long, ConcurrentStack<BattleDto>>();
        }

        protected override ConcurrentDictionary<Guid, BattleDto> Battles { get; }
        protected override ConcurrentDictionary<long, ConcurrentStack<BattleDto>> UsersBattles { get; }

        protected override void CheckWinner(BattleDto battle)
        {
            throw new NotImplementedException();
        }
    }
}
