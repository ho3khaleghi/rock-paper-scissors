using Core.Kernel.Service;

namespace RockPaperScissors.Service.User.Dto
{
    public class SignupDto : IDto
    {
        public string? UserName { get; set; }
        public byte[]? Password { get; set; }
        public string? Email { get; set; }
    }
}
