using RockPaperScissors.Repository.Battle;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class AddPlayerChoiceService(IBattleRepository battleRepository) : IAddPlayerChoiceService
    {
        public Task<AddPlayerChoiceDto> HandleAsync(AddPlayerChoiceDto request)
        {
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
