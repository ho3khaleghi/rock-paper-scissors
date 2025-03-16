using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Queue;

namespace RockPaperScissors.Repository.Helpers
{
    public interface IQueueFactory : ISingletonDependencyInjection
    {
        IMatchmakingQueueRepository CreateQueueRepository(GameOption gameOption);
    }
}
