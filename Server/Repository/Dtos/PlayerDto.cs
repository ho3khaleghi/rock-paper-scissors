using Core.Kernel.Service;

namespace RockPaperScissors.Repository.Dtos
{
    public class PlayerDto : DtoBase<long>
    {
        public long? UserId { get; set; }
        public int? Rank { get; set; }
        public string? Title { get; set; }
        public int? Badge { get; set; }
        public int? TotalMatch { get; set; }
        public int? TotalWin { get; set; }
        public int? TotalLose { get; set; }
        public int? TotalScore { get; set; }

        public UserDto? User { get; set; }
    }
}
