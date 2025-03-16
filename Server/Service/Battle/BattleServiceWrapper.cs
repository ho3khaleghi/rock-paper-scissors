using Core.Kernel.Service;
using RockPaperScissors.Service.Battle.Dto;

namespace RockPaperScissors.Service.Battle
{
    public class BattleServiceWrapper : ServiceWrapper, IBattleServiceWrapper
    {
        private readonly IAddBattleService _addBattleService;
        private readonly IAddPlayerChoiceService _addPlayerChoiceService;
        private readonly ICheckBattleWinnerService _checkBattleWinnerService;

        public BattleServiceWrapper(IServiceHandler serviceHandler,
            IAddBattleService addBattleService,
            IAddPlayerChoiceService addPlayerChoiceService,
            ICheckBattleWinnerService checkBattleWinnerService) : base(serviceHandler)
        {
            _addBattleService = addBattleService;
            _addPlayerChoiceService = addPlayerChoiceService;
            _checkBattleWinnerService = checkBattleWinnerService;
        }

        public async Task<IServiceResponse<AddPlayerBattleDto>> AddBattleAsync(AddPlayerBattleDto request) =>
            await ServiceHandler.HandleAsync(async () => await _addBattleService.HandleAsync(request));

        public async Task<IServiceResponse<AddPlayerChoiceDto>> AddBattleAsync(AddPlayerChoiceDto request) =>
            await ServiceHandler.HandleAsync(async () => await _addPlayerChoiceService.HandleAsync(request));

        public async Task<IServiceResponse<CheckBattleWinnerDto>> CheckBattleWinnerAsync(CheckBattleWinnerDto request) =>
            await ServiceHandler.HandleAsync(async () => await _checkBattleWinnerService.HandleAsync(request));
    }
}
