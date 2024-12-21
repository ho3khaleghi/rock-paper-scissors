using Core.Kernel.Service;
using RockPaperScissors.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RockPaperScissors.Service")]
namespace RockPaperScissors.Repository.Dtos
{
    public class UserDto : DtoBase<long>
    {
        public string? UserName { get; set; }
        public byte[]? Password { get; set; }
        internal byte[]? Salt { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
    }

    public static class UserMapper
    {
        public static User? ToEntity(this UserDto? user) =>
            user is null
            ? null
            : new User
            {
                Key = user.Key,
                UserName = user.UserName,
                Password = user.Password,
                Salt = user.Salt,
                LastLoginDateTime = user.LastLoginDateTime,
                CreationDateTime = user.CreationDateTime
            };

        public static UserDto? ToDto(this User? user) =>
            user is null
            ? null
            : new UserDto
            {
                Key = user.Key,
                UserName = user.UserName,
                Password = user.Password,
                LastLoginDateTime = user.LastLoginDateTime,
                CreationDateTime = user.CreationDateTime
            };
    }
}
