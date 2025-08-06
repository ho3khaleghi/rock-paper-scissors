using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfOneQueueRepository : MatchmakingQueueAbstraction, IBestOfOneQueueRepository
    {
        protected override ConcurrentQueue<string> Queue { get; } = new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers { get; } = new();
    }
}
