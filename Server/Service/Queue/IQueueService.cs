using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Queue
{
    public interface IQueueService
    {
        Task<QueueDto> JoinQueueAsync(QueueDto joinQueue);
        Task<QueueDto> LeaveQueueAsync(QueueDto leaveQueue);
        Task<QueueDto> GetMatchAsync(QueueDto getMatch);
    }
}
