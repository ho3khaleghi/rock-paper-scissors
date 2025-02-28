using Core.Kernel.Utils;
using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;
using System.Security.Cryptography;

namespace RockPaperScissors.Service.User
{
    public class UserSignupService(IProfileRepository profileRepository) : IUserSignupService
    {
        public async Task<UserDto?> HandleAsync(UserDto? user)
        {
            if (user == null) return null;

            if (!Validate(user)) return null;

            var salt = RandomNumberGenerator.GetBytes(32);

            user.Password = HashUtil.CalculatePasswordHash(user.Password!, salt);
            user.Salt = salt;
            user.CreationDateTime = DateTime.UtcNow;

            var profile = new ProfileDto
            {
                Key = user.Key,
                Email = string.Empty,
                User = user
            };

            await profileRepository.CreateAsync(profile);

            return profile.User;
        }

        private bool Validate(UserDto user)
        {
            if (user.Password == null) return false;

            if (string.IsNullOrWhiteSpace(user.UserName)) return false;

            return true;
        }
    }
}
