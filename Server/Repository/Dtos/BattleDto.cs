using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Dtos;

public class BattleDto : IDto
{
    public Guid BattleId { get; set; }
    public GameOption GameOption { get; set; }
    public string PlayerOneId { get; set; } = string.Empty;
    public string PlayerTwoId { get; set; } = string.Empty;
    public BattlePlayerDto PlayerOne { get; set; } = new();
    public BattlePlayerDto PlayerTwo { get; set; } = new();
    public string? WinnerId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? EndedAt { get; set; }
}