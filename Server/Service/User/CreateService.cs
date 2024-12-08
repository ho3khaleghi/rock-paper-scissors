using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public class CreateService(IUserRepository userRepository) : ICreateService
    {
        public async Task<UserDto?> HandleAsync(UserDto? userDto)
        {
            if (userDto == null) return null;

            return await userRepository.Create(userDto);
        }
    }
}
