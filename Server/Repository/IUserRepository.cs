using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public interface IUserRepository : IPerLifetimeScopeDependencyInjection
    {
        Task<UserDto?> GetAsync(long id);
        Task<UserDto?> GetAsync(string userName);
        Task<UserDto?> CreateAsync(UserDto user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<UserDto> ChangePasswordAsync(UserDto user);
        Task<bool> CheckUserNameAsync(string username);
    }
}
