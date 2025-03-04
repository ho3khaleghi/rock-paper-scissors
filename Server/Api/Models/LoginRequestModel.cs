using Core.Kernel.Helper;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Api.Models
{
    public class LoginRequestModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public static class LoginRequestModelMapper
    {
        public static UserDto? ToDto(this LoginRequestModel? user) =>
            user is null
            ? null
            : new UserDto
            {
                UserName = user.UserName,
                Password = user.Password.Decode()
            };
        public static LoginRequestModel? ToModel(this UserDto? user) =>
            user is null
            ? null
            : new LoginRequestModel
            {
                UserName = user.UserName
            };
    }
}
