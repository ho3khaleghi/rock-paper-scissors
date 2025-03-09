using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfThreeQueueRepository : MatchmakingQueueAbstraction, IBestOfThreeQueueRepository
    {
        public BestOfThreeQueueRepository(ILogger<BestOfThreeQueueRepository> logger) : base(logger)
        {
        }

        protected override ConcurrentQueue<string> Queue => new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers => new();
    }
}
