using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public interface IUserServiceWrapper : IPerLifetimeScopeDependencyInjection
    {
        Task<UserDto> GetAsync(int id);
        Task<UserDto> GetAsync(string userName);
        Task<UserDto?> CreateAsync(UserDto? userDto);
        Task<UserDto?> UpdateAsync(UserDto? userDto);
        Task<UserDto> DeleteAsync(int id);
        Task<UserDto?> LoginAsync(string? userName, byte[]? password);
        Task<UserDto> LogoutAsync(UserDto userDto);
        Task<bool> CheckUserNameAsync(string userName);
    }
}
