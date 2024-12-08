using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;
using System.Security.Cryptography;

namespace RockPaperScissors.Service.User
{
    public class LoginService(IUserRepository userRepository) : ILoginService
    {
        public async Task<UserDto?> HandleAsync(UserDto? userDto)
        {
            //TODO: this should be check in separate if clause and return spcific message based on the condition.
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.UserName) || userDto.Password is null) return null;

            var user = await userRepository.Get(userDto.UserName);

            if (user == null) return user;

            if (!CryptographicOperations.FixedTimeEquals(userDto.Password, user.Password)) return user;

            user.LastLoginDateTime = DateTime.UtcNow;

            await userRepository.UpdateAsync(user);

            return user;
        }
    }
}
