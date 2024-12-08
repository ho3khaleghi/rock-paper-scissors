using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public interface IUserRepository
    {
        Task<UserDto?> Get(int id);
        Task<UserDto?> Get(string userName);
        Task<UserDto?> Create(UserDto user);
        Task UpdateAsync(UserDto user);
        Task<bool> CheckUserName(string username);
    }
}
