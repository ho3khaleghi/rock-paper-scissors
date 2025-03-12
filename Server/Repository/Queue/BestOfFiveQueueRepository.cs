using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfFiveQueueRepository : MatchmakingQueueAbstraction, IBestOfFiveQueueRepository
    {
        public BestOfFiveQueueRepository() : base()
        {
            Instance = "best-of-five";
            Queue = new ConcurrentQueue<string>();
            QueuedUsers = new ConcurrentDictionary<string, DateTime>();
        }

        protected override ConcurrentQueue<string> Queue { get; }
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers { get; }
        protected override string Instance { get; }
    }
}
