using RockPaperScissors.Repository.Helpers;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Service.Queue
{
    public class JoinQueueService(IQueueFactory queueFactory) : IJoinQueueService
    {
        public Task<JoinQueueDto> HandleAsync(JoinQueueDto request)
        {
            var queueRepository = queueFactory.CreateQueueRepository(request.GameOption);

            if (queueRepository.EnqueueUser(request.UserName))
            {
                return Task.FromResult(request);
            }
            else
            {
                throw new Exception("User is already in the queue.");
            }
        }
    }
}
