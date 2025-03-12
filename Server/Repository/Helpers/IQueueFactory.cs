using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Enums;
using RockPaperScissors.Repository.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Repository.Helpers
{
    public interface IQueueFactory : ISingletonDependencyInjection
    {
        IMatchmakingQueueRepository CreateQueueRepository(GameOption gameOption);
    }
}
