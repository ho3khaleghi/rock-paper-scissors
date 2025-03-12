using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public class BestOfFiveQueueRepository : MatchmakingQueueAbstraction, IBestOfFiveQueueRepository
    {
        public BestOfFiveQueueRepository() : base()
        {
        }

        protected override ConcurrentQueue<string> Queue => new();
        protected override ConcurrentDictionary<string, DateTime> QueuedUsers => new();
    }
}
