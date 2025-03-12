using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Service.Queue
{
    public class QueueServiceWrapper : ServiceWrapper, IQueueServiceWrapper
    {
        private readonly IJoinQueueService _joinQueueService;
        private readonly ILeaveQueueService _leaveQueueService;

        public QueueServiceWrapper(IServiceHandler serviceHandler,
            IJoinQueueService joinQueueService,
            ILeaveQueueService leaveQueueService) : base(serviceHandler)
        {
            _joinQueueService = joinQueueService;
            _leaveQueueService = leaveQueueService;
        }

        public Task<QueueDto> GetMatchAsync(QueueDto getMatch)
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceResponse<JoinQueueDto>> JoinQueueAsync(JoinQueueDto joinQueue) =>
            await ServiceHandler.HandleAsync(async () => await _joinQueueService.HandleAsync(joinQueue));

        public async Task<IServiceResponse<LeaveQueueDto>> LeaveQueueAsync(LeaveQueueDto leaveQueue) =>
            await ServiceHandler.HandleAsync(async () => await _leaveQueueService.HandleAsync(leaveQueue));
    }
}
