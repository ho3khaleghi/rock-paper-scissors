using Core.Kernel.Service;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Service.Queue
{
    public interface IJoinQueueService : IService<JoinQueueDto, JoinQueueDto>
    {
    }
}
