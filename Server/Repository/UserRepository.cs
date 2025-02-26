using Core.Kernel.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public class UserRepository(IRepository repository) : IUserRepository
    {
        public async Task<UserDto?> CreateAsync(UserDto user)
        {
            var entity = user.ToEntity() ?? throw new Exception("User cannot be null.");

            await repository.CreateAsync(entity);

            //user.Id = entity?.Id ?? throw new Exception("User entity cannot be null.");

            return user;
        }

        public async Task<UserDto?> GetAsync(long id) => (await repository.GetAsync<User>(id)).ToDto();

        public async Task<UserDto?> GetAsync(string userName) => (await repository.ToQueryable<User>().FirstOrDefaultAsync(u => u.UserName!.Equals(userName))).ToDto();

        public async Task<UserDto> UpdateAsync(UserDto user)
        {
            var entity = await repository.GetAsync<User>(user.Id);

            entity.Password = user.Password;
            entity.LastLoginDateTime = user.LastLoginDateTime;

            await repository.UpdateAsync(entity);

            return entity.ToDto()!;
        }

        public async Task<bool> CheckUserNameAsync(string username) => await repository.ToQueryable<User>().AnyAsync(u => u.UserName == username);
    }
}
