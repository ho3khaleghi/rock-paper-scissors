using Core.Kernel.Service;

namespace RockPaperScissors.Repository.Dtos
{
    public class MatchDto : DtoBase<long>
    {
        public Guid? MatchSessionId { get; set; }
        public long? Player1Id { get; set; }
        public long? Player2Id { get; set; }
        public int? DifficultyLevel { get; set; }
        public int? MatchMode { get; set; }
        public int? MatchStatus { get; set; }
        public int? RoundCount { get; set; }
        public long? WinnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public PlayerDto? Player1 { get; set; }
        public PlayerDto? Player2 { get; set; }
        public PlayerDto? Winner { get; set; }
    }
}