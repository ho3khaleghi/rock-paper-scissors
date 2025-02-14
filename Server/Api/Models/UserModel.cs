using Core.Kernel.Helper;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Api.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }

    public static class UserModelMapper
    {
        public static UserDto? ToDto(this UserModel? user) =>
            user is null
            ? null
            : new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password.Decode(),
                Email = user.Email
            };

        public static UserModel? ToModel(this UserDto? user) =>
            user is null
            ? null
            : new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
    }
}
