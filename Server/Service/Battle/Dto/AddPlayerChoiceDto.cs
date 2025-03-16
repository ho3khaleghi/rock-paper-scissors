using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Service.Battle.Dto
{
    public class AddPlayerChoiceDto : IDto
    {
        public Guid BattleId { get; set; }
        public string PlayerId { get; set; } = string.Empty;
        public PlayerChoice PlayerChoice { get; set; }
        public GameOption GameOption { get; set; }
    }
}
