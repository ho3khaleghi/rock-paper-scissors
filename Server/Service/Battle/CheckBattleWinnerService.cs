using RockPaperScissors.Repository.Battle;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class CheckBattleWinnerService(IBattleRepository battleRepository) : ICheckBattleWinnerService
    {
        public Task<CheckBattleWinnerDto> HandleAsync(CheckBattleWinnerDto request)
        {
            if(battleRepository.TryCheckWinner(request.BattleId, out var winnerId))
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
