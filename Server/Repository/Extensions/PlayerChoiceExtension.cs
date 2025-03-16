using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Extensions
{
    public static class PlayerChoiceExtension
    {
        public static bool? Compare(this PlayerChoice playerChoice1, PlayerChoice playerChoice2)
        {
            if (playerChoice1 == playerChoice2) return null;

            return playerChoice1 switch
            {
                PlayerChoice.Rock => playerChoice2 == PlayerChoice.Scissors,
                PlayerChoice.Paper => playerChoice2 == PlayerChoice.Rock,
                PlayerChoice.Scissors => (bool?)(playerChoice2 == PlayerChoice.Paper),
                _ => throw new ArgumentException("Invalid player choice"),
            };
        }
    }
}
