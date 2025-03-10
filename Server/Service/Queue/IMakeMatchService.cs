using Core.Kernel.Service;
using RockPaperScissors.Service.Queue.Dto;

namespace RockPaperScissors.Service.Queue
{
    public interface IMakeMatchService : IService<MatchmakingDto, MatchmakingDto>
    {
    }
}
