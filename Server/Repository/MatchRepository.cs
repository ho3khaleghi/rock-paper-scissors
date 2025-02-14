using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Kernel.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public class MatchRepository(IRepository repository) : IMatchRepository
    {
        public Task<MatchDto?> Create(MatchDto match)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchDto?> Get(long id) => await repository.GetAsync<MatchDto>(id);

        public async Task<MatchDto?> GetPlayerCurrentMatch(long playerId) => (await repository.ToQueryable<Match>().FirstOrDefaultAsync(m => m.Player1Id == playerId)).ToDto();

        public Task<IList<MatchDto?>?> GetPlayerMatches(long playerId)
        {
            throw new NotImplementedException();
        }
    }
}
