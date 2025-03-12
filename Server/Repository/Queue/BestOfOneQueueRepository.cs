using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfOneQueueRepository : MatchmakingQueueAbstraction, IBestOfOneQueueRepository
    {
        public BestOfOneQueueRepository() : base()
        {
        }

        protected override ConcurrentQueue<string> Queue => new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers => new();
    }
}
