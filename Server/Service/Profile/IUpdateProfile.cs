using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile
{
    public interface IUpdateProfile : IService<ProfileDto, ProfileDto?>
    {
    }
}
