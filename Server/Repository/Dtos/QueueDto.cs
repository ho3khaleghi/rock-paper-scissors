using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Dtos
{
    public class QueueDto : IDto
    {
        public string UserName { get; set; } = null!;
        public GameOption GameOption { get; set; }
    }
}
