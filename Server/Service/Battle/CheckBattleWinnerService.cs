using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class CheckBattleWinnerService(IBattleFactory battleFactory) : ICheckBattleWinnerService
    {
        public Task<CheckBattleWinnerDto> HandleAsync(CheckBattleWinnerDto request)
        {
            var repository = battleFactory.CreateBattleRepository(request.GameOption);

            if(repository.TryCheckWinner(request.BattleId, out var winnerId))
            {
                request.WinnerId = winnerId;
                return Task.FromResult(request);
            }
            else
            {
                throw new Exception("Couldn't check the winner.");
            }
        }
    }
}
