using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class AddPlayerChoiceService(IBattleFactory battleFactory) : IAddPlayerChoiceService
    {
        public Task<AddPlayerChoiceDto> HandleAsync(AddPlayerChoiceDto request)
        {
            var battleRepository = battleFactory.CreateBattleRepository(request.GameOption);

            if(battleRepository.TryAddPlayerChoice(request.BattleId, request.PlayerId, request.PlayerChoice))
            {
                return Task.FromResult(request);
            }
            else
            {
                throw new Exception("Couldn't add player choice.");
            }
        }
    }
}
