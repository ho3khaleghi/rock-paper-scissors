using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Repository.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public byte[]? Password { get; set; }
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
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                LastLoginDateTime = user.LastLoginDateTime,
                CreationDateTime = user.CreationDateTime
            };

        public static UserDto? ToDto(this User? user) =>
            user is null
            ? null
            : new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                LastLoginDateTime = user.LastLoginDateTime,
                CreationDateTime = user.CreationDateTime
            };
    }
}
