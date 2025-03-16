using Core.Kernel.Dependency;
using Core.Kernel.Service;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public interface IBattleServiceWrapper : IPerLifetimeScopeDependencyInjection
    {
        Task<IServiceResponse<AddPlayerBattleDto>> AddBattleAsync(AddPlayerBattleDto request);
        Task<IServiceResponse<AddPlayerChoiceDto>> AddBattleAsync(AddPlayerChoiceDto request);
        Task<IServiceResponse<CheckBattleWinnerDto>> CheckBattleWinnerAsync(CheckBattleWinnerDto request);
    }
}
