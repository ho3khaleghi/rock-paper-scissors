using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Dtos
{
    public class PlayerChoicesDto(Guid battleId, string playerId, PlayerChoice[] playerChoices)
    {
        public Guid BattleId { get; } = battleId;
        public string PlayerId { get; } = playerId;
        public PlayerChoice[] PlayerChoices { get; } = playerChoices;
    }
}
