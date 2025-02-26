using System.Security.Cryptography;
using Core.Kernel.Utils;
using JWTService;
using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public class LoginService(IUserRepository userRepository, IUserTokenManager userTokenManager) : ILoginService
    {
        public async Task<UserDto?> HandleAsync(UserDto? requestDto)
        {
            //TODO: this should be checked in separate if-clauses and return specific message based on the condition.
            if (requestDto == null || string.IsNullOrWhiteSpace(requestDto.UserName) || requestDto.Password is null) return null;

            var user = await userRepository.GetAsync(requestDto.UserName);

            if (user == null) return user;

            var hashedPassword = HashUtil.CalculatePasswordHash(requestDto.Password, user.Salt!);

            if (!CryptographicOperations.FixedTimeEquals(hashedPassword, user.Password)) return null;

            user.LastLoginDateTime = DateTime.UtcNow;

            await userRepository.UpdateAsync(user);

            var token = userTokenManager.GenerateToken(new JWTService.Model.User
            {
                Id = user.Id,
                Username = user.UserName
            });

            if (string.IsNullOrWhiteSpace(token)) return user;

            user.AccessToken = token;

            //TODO: User Session should be created.
            //TODO: Login token should be created.

            return user;
        }
    }
}
