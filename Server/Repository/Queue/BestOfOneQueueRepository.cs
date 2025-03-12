using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfOneQueueRepository : MatchmakingQueueAbstraction, IBestOfOneQueueRepository
    {
        public BestOfOneQueueRepository() : base()
        {
            Instance = "best-of-one";
            Queue = new ConcurrentQueue<string>();
            QueuedUsers = new ConcurrentDictionary<string, DateTime>();
        }

        protected override ConcurrentQueue<string> Queue { get; }
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers { get; }
        protected override string Instance { get; }
    }
}
