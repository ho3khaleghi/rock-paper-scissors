using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public interface IUserRepository : IPerLifetimeScopeDependencyInjection
    {
        Task<UserDto?> Get(int id);
        Task<UserDto?> Get(string userName);
        Task<UserDto?> Create(UserDto user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<bool> CheckUserName(string username);
    }
}
