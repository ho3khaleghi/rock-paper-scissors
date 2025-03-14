using Core.Kernel.Service;
using RockPaperScissors.Repository.Enums;

namespace RockPaperScissors.Repository.Dtos;

public class BattleDto : IDto
{
    public Guid BattleId { get; set; }
    public GameOption GameOption { get; set; }
    public long PlayerOneId { get; set; }
    public long PlayerTwoId { get; set; }
    public BattlePlayerDto PlayerOne { get; set; } = new();
    public BattlePlayerDto PlayerTwo { get; set; } = new();
    public long WinnerId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? EndedAt { get; set; }
}