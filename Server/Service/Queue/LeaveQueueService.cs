using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Service.Queue
{
    public class LeaveQueueService(IQueueFactory queueFactory) : ILeaveQueueService
    {
        public Task<LeaveQueueDto> HandleAsync(LeaveQueueDto request)
        {
            var username = request.UserName;
            if (request.GameOption != null)
            {
                var queueRepository = queueFactory.CreateQueueRepository(request.GameOption.Value);

                queueRepository.TryDequeueUser(out username);

                return Task.FromResult(request);
            }

            //Remove the user from all the queues
            foreach (var gameOption in Enum.GetValues<GameOption>())
            {
                var queueRepository = queueFactory.CreateQueueRepository(gameOption);
                queueRepository.TryDequeueUser(out username);
            }

            return Task.FromResult(request);
        }
    }
}
