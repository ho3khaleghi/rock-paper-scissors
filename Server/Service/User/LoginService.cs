using JWTService;
using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;
using System.Security.Cryptography;

namespace RockPaperScissors.Service.User
{
    public class LoginService(IUserRepository userRepository, IUserTokenManager userTokenManager) : ILoginService
    {
        public async Task<UserDto?> HandleAsync(UserDto? userDto)
        {
            //TODO: this should be checked in separate if-clauses and return specific message based on the condition.
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.UserName) || userDto.Password is null) return null;

            var user = await userRepository.Get(userDto.UserName);

            if (user == null) return user;

            if (!CryptographicOperations.FixedTimeEquals(userDto.Password, user.Password)) return user;

            user.LastLoginDateTime = DateTime.UtcNow;

            await userRepository.UpdateAsync(user);

            var token = userTokenManager.GenerateToken(new JWTService.Model.User
            {
                Id = user.Id,
                Username = user.UserName
            });

            if (string.IsNullOrWhiteSpace(token)) return user;

            user.AccessToken = token;

            //TODO: User Session sould be created.
            //TODO: Login token should be created.

            return user;
        }
    }
}
