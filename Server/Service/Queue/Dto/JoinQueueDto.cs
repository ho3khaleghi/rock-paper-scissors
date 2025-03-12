using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Service.Queue.Dto
{
    public class JoinQueueDto : IDto
    {
        public string UserName { get; set; } = null!;
        public GameOption GameOption { get; set; }
    }
}
