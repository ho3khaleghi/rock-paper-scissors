using Core.Kernel.DataAccess.Model;
using Core.Kernel.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;
using RockPaperScissors.Repository.Dtos;
using System.Security.Cryptography;

namespace RockPaperScissors.Repository
{
    public class UserRepository
    {
        private readonly IRepository _repository;

        public UserRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto?> Create(UserDto user)
        {
            var entity = user.ToEntity() ?? throw new Exception("User cannot be null.");

            await _repository.CreateAsync(entity);

            user.Id = entity?.Id ?? throw new Exception("User entity cannot be null.");

            return user;
        }

        public async Task<UserDto?> Get(int id) => (await _repository.GetAsync<User>(id)).ToDto();

        public async Task<UserDto?> Get(string userName) => (await _repository.ToQueryable<User>().FirstOrDefaultAsync(u => u.UserName!.Equals(userName))).ToDto();

        public async Task UpdateAsync(UserDto user)
        {
            var entity = await _repository.GetAsync<User>(user.Id);

            entity.Password = user.Password;
            entity.LastLoginDateTime = user.LastLoginDateTime;

            await _repository.UpdateAsync(entity);
        }

        public async Task<bool> CheckUserName(string username) => await _repository.ToQueryable<User>().AnyAsync(u => u.UserName == username);

        //TODO: this should be a service!!!
        public async Task<bool> Login(string userName, byte[] password)
        {
            var user = await _repository.ToQueryable<User>().FirstOrDefaultAsync(u => u.UserName!.Equals(userName));
            
            if (user == null) return false;

            if (!CryptographicOperations.FixedTimeEquals(password, user.Password)) return false;

            user.LastLoginDateTime = DateTime.UtcNow;

            return await _repository.UpdateAsync(user);
        }
    }
}
