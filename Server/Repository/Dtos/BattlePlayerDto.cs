using System.Collections.Concurrent;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Dtos;

public class BattlePlayerDto
{
    public long PlayerId { get; set; }
    public Guid BattleId { get; set; }
    public int Score { get; set; }
    public ConcurrentQueue<PlayerChoice> PlayerChoices { get; set; } = new();
}