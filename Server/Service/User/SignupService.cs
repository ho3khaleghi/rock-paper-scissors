using Core.Kernel.Utils;
using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.User.Dto;
using System.Security.Cryptography;

namespace RockPaperScissors.Service.User
{
    public class SignupService(IProfileRepository profileRepository) : ISignupService
    {
        public async Task<UserDto?> HandleAsync(SignupDto signupDto)
        {
            if (!Validate(signupDto)) return null;

            var userDto = new UserDto()
            {
                UserName = signupDto.UserName,
            };

            var salt = RandomNumberGenerator.GetBytes(32);

            userDto.Password = HashUtil.CalculatePasswordHash(signupDto.Password!, salt);
            userDto.Salt = salt;
            userDto.CreationDateTime = DateTime.UtcNow;

            var profile = new ProfileDto
            {
                Key = userDto.Key,
                Email = signupDto.Email,
                User = userDto
            };

            await profileRepository.CreateAsync(profile);

            return profile.User;
        }

        private bool Validate(SignupDto signupDto)
        {
            if (signupDto.Password == null || signupDto.Password.Length != 32) return false;

            if (string.IsNullOrWhiteSpace(signupDto.UserName)) return false;

            if (string.IsNullOrWhiteSpace(signupDto.Email)) return false;

            return true;
        }
    }
}
