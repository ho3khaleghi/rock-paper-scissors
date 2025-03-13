using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfThreeQueueRepository : MatchmakingQueueAbstraction, IBestOfThreeQueueRepository
    {
        public BestOfThreeQueueRepository() : base()
        {
            Instance = "best-of-three";
            Queue = new ConcurrentQueue<string>();
            QueuedUsers = new ConcurrentDictionary<string, DateTime>();
        }

        protected override ConcurrentQueue<string> Queue { get; }
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers { get; }
        protected override string Instance { get; }
    }
}
