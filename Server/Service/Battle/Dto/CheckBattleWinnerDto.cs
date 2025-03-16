using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Service.Battle.Dto
{
    public class CheckBattleWinnerDto : IDto
    {
        public Guid BattleId { get; set; }
        public GameOption GameOption { get; set; }
        public string? WinnerId { get; set; }
    }
}
