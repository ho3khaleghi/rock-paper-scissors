using Core.Kernel.Dependency;

namespace RockPaperScissors.Repository.Queue
{
    public interface IMatchmakingQueueRepository
    {
        bool EnqueueUser(string username);
        bool TryDequeueUser(out string? username);
        bool TryGetNextMatchPlayers(out (string player1, string player2) matchPlayers);
    }
}
