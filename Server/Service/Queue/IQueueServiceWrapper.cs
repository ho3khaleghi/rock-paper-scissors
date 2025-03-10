using Core.Kernel.Dependency;
using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Service.Queue
{
    public interface IQueueServiceWrapper : IPerLifetimeScopeDependencyInjection
    {
        Task<IServiceResponse<JoinQueueDto>> JoinQueueAsync(JoinQueueDto joinQueue);
        Task<IServiceResponse<LeaveQueueDto>> LeaveQueueAsync(LeaveQueueDto leaveQueue);
        Task<QueueDto> GetMatchAsync(QueueDto getMatch);
    }
}
