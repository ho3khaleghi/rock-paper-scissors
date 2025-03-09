using Core.Kernel.Dependency;

namespace RockPaperScissors.Repository.Queue
{
    public interface IBestOfFiveQueueRepository : IMatchmakingQueueRepository, ISingletonDependencyInjection
    {

    }
}
