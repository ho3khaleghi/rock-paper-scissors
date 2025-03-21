using RockPaperScissors.Repository.Battle;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class AddBattleService(IBattleRepository battleRepository) : IAddBattleService
    {
        public Task<AddPlayerBattleDto> HandleAsync(AddPlayerBattleDto request)
        {
            if (battleRepository.TryAddBattle(new Repository.Dtos.BattleDto
            {
                BattleId = request.BattleId,
                GameOption = request.GameOption,
                PlayerOneId = request.PlayerOneId,
                PlayerTwoId = request.PlayerTwoId
            }))
            {
                return Task.FromResult(request);
            }
            else
            {
                throw new Exception("Couldn't add the battle.");
            }
        }
    }
}