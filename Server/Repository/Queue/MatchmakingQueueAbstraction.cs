using System.Collections.Concurrent;

namespace RockPaperScissors.Repository.Queue
{
    public abstract class MatchmakingQueueAbstraction() : IMatchmakingQueueRepository
    {
        protected abstract ConcurrentQueue<string> Queue { get; }
        protected abstract ConcurrentDictionary<string, DateTime> QueuedUsers { get; }
        protected abstract string Instance { get; }

        public bool EnqueueUser(string username)
        {
            if (QueuedUsers.TryAdd(username, DateTime.UtcNow))
            {
                Queue.Enqueue(username);
                return true;
            }

            return false;
        }

        public bool TryDequeueUser(out string username)
        {
            if (Queue.TryDequeue(out username!))
            {
                QueuedUsers.TryRemove(username, out _);
                return true;
            }

            username = null!;

            return false;
        }

        public DateTime? GetQueuedUserTime(string username)
        {
            if (QueuedUsers.TryGetValue(username, out var time))
            {
                return time;
            }

            return null;
        }

        public bool TryGetNextMatchPlayers(out (string player1, string player2) matchPlayers)
        {
            matchPlayers = (null!, null!);

            if (Queue.Count < 2) return false; // Not enough players to form a match

            var gotFirst = TryDequeueUser(out var player1);
            var gotSecond = TryDequeueUser(out var player2);

            if (gotFirst && gotSecond)
            {
                matchPlayers = (player1, player2);

                return true;
            }

            // TODO: In this scenario, we should requeue the player in the same position in the queue as they had before
            // If failed to dequeue both, enqueue the one you got back (rare scenario)
            if (gotFirst) EnqueueUser(player1!);
            if (gotSecond) EnqueueUser(player2!);

            return false;
        }
    }
}
