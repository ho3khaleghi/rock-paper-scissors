using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class AddBattleService(IBattleFactory battleFactory) : IAddBattleService
    {
        public Task<AddPlayerBattleDto> HandleAsync(AddPlayerBattleDto request)
        {
            var repository = battleFactory.CreateBattleRepository(request.GameOption);

            if (repository.TryAddBattle(new Repository.Dtos.BattleDto
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