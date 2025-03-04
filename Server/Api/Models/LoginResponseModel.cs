using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Api.Models
{
    public class LoginResponseModel
    {
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? AccessToken { get; set; }
    }

    public static class LoginResponseModelMapper
    {
        public static LoginResponseModel? ToLoginResponseModel(this UserDto? userDto) =>
            userDto is null
            ? null
            : new LoginResponseModel
            {
                UserId = userDto.Id,
                UserName = userDto.UserName,
                AccessToken = userDto.AccessToken
            };
    }
}
