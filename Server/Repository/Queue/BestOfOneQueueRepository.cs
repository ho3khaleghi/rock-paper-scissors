using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfOneQueueRepository : MatchmakingQueueAbstraction, IBestOfOneQueueRepository
    {
        public BestOfOneQueueRepository(ILogger<BestOfOneQueueRepository> logger) : base(logger)
        {
        }

        protected override ConcurrentQueue<string> Queue => new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers => new();
    }
}
