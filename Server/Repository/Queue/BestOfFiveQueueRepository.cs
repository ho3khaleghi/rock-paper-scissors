using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfFiveQueueRepository : MatchmakingQueueAbstraction, IBestOfFiveQueueRepository
    {
        public BestOfFiveQueueRepository(ILogger<BestOfFiveQueueRepository> logger) : base(logger)
        {
        }

        protected override ConcurrentQueue<string> Queue => new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers => new();
    }
}
