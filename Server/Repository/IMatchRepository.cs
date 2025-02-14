using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public interface IMatchRepository : IPerLifetimeScopeDependencyInjection
    {
        Task<MatchDto?> Get(long id);
        Task<MatchDto?> GetPlayerCurrentMatch(long playerId);
        Task<IList<MatchDto?>?> GetPlayerMatches(long playerId);
        Task<MatchDto?> Create(MatchDto match);
    }
}
