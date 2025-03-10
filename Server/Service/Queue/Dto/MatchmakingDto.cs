using Core.Kernel.Service;

namespace RockPaperScissors.Service.Queue.Dto
{
    public class MatchmakingDto : IDto
    {
        public Guid Guid { get; set; }
        public string Player1 { get; set; } = null!;
        public string Player2 { get; set; } = null!;
    }
}
