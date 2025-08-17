using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile;

public interface IGetUserProfileService : IService<ProfileDto, ProfileDto?>
{
}