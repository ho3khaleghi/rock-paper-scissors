using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Dtos
{
    public class PlayerChoiceDto(string playerId, PlayerChoice playerChoice)
    {
        public string PlayerId { get; } = playerId;
        public PlayerChoice PlayerChoices { get; } = playerChoice;
    }
}
