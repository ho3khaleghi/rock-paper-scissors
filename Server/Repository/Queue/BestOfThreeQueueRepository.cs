using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfThreeQueueRepository : MatchmakingQueueAbstraction, IBestOfThreeQueueRepository
    {
        public BestOfThreeQueueRepository() : base()
        {
        }

        protected override ConcurrentQueue<string> Queue => new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers => new();
    }
}
