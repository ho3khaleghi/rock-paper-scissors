using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Service.Battle.Dto
{
    public class AddPlayerBattleDto : IDto
    {
        public Guid BattleId { get; set; }
        public string PlayerOneId { get; set; } = string.Empty;
        public string PlayerTwoId { get; set; } = string.Empty;
        public GameOption GameOption { get; set; }
    }
}
