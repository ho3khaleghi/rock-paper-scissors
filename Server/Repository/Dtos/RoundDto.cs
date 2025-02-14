using Core.Kernel.Service;

namespace RockPaperScissors.Repository.Dtos
{
    public class RoundDto : DtoBase<long>
    {
        public long? MatchId { get; set; }
        public int? RoundNumber { get; set; }
        public int? Player1Move { get; set; }
        public int? Player2Move { get; set; }
        public long? WinnerId { get; set; }
        public int? Result { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MatchDto? Match { get; set; }
    }
}
