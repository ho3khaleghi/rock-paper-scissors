namespace RockPaperScissors.Repository.Dtos
{
    public class BattleUpdateNotificationDto(Guid battleId, PlayerChoiceDto playerOneChoice, PlayerChoiceDto playerTwoChoice)
    {
        public Guid BattleId { get; set; } = battleId;
        public PlayerChoiceDto PlayerOneChoice { get; set; } = playerOneChoice;
        public PlayerChoiceDto PlayerTwoChoice { get; set; } = playerTwoChoice;
    }
}
