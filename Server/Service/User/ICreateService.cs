using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.User
{
    public interface ICreateService : IService<UserDto?, UserDto?>
    {
    }
}
