using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public class LogoutService(IUserRepository userRepository) : ILogoutService
    {
        public async Task<UserDto> HandleAsync(UserDto request)
        {
            //TODO: Remove the user session here.
            //TODO: Login token should be expired.

            return await userRepository.UpdateAsync(request);
        }
    }
}
