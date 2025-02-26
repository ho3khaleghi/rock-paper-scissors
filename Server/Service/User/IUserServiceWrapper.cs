using Core.Kernel.Dependency;
using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public interface IUserServiceWrapper : IPerLifetimeScopeDependencyInjection
    {
        Task<UserDto> GetAsync(int id);
        Task<UserDto> GetAsync(string userName);
        Task<ServiceResponse<UserDto>> SignupAsync(UserDto? userDto);
        Task<UserDto?> UpdateAsync(UserDto? userDto);
        Task<UserDto> DeleteAsync(int id);
        Task<ServiceResponse<UserDto>> LoginAsync(string? userName, byte[]? password);
        Task<UserDto> LogoutAsync(UserDto userDto);
        Task<bool> CheckUserNameAsync(string userName);
    }
}
