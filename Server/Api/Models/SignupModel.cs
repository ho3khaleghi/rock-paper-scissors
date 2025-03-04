using Core.Kernel.Helper;
using RockPaperScissors.Service.User.Dto;

namespace RockPaperScissors.Api.Models
{
    public class SignupModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }

    public static class SignupModelMapper
    {
        public static SignupDto ToDto(this SignupModel signup) =>
            new()
            {
                UserName = signup.UserName,
                Password = signup.Password.Decode(),
                Email = signup.Email
            };
    }
}
