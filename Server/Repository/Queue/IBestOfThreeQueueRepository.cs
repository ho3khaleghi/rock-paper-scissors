using Core.Kernel.Dependency;

namespace RockPaperScissors.Repository.Queue
{
    public interface IBestOfThreeQueueRepository : IMatchmakingQueueRepository, ISingletonDependencyInjection
    {

    }
}
