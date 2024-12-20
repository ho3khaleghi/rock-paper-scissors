using Core.Kernel.Utils;
using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;
using System.Security.Cryptography;

namespace RockPaperScissors.Service.User
{
    public class UserSignupService(IUserRepository userRepository) : IUserSignupService
    {
        public async Task<UserDto?> HandleAsync(UserDto? user)
        {
            if (user == null) return null;

            if (!Validate(user)) return null;

            var salt = RandomNumberGenerator.GetBytes(32);

            user.Password = HashUtil.CalculatePasswordHash(user.Password!, salt);
            user.Salt = salt;
            user.CreationDateTime = DateTime.UtcNow;

            return await userRepository.Create(user);
        }

        private bool Validate(UserDto user)
        {
            if (user.Password == null) return false;

            if (string.IsNullOrWhiteSpace(user.UserName)) return false;

            return true;
        }
    }
}
