using Core.Kernel.Dependency;

namespace RockPaperScissors.Repository.Queue
{
    public interface IBestOfOneQueueRepository : IMatchmakingQueueRepository, ISingletonDependencyInjection
    {

    }
}
