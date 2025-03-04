using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.User.Dto;

namespace RockPaperScissors.Service.User
{
    public interface ISignupService : IService<SignupDto, UserDto?>
    {
    }
}
