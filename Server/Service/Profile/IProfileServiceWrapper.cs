using Core.Kernel.Dependency;
using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile
{
    public interface IProfileServiceWrapper : IPerLifetimeScopeDependencyInjection
    {
        Task<ServiceResponse<ProfileDto?>> UpdateAsync(ProfileDto profileDto);
        Task<IServiceResponse<ProfileDto?>> GetUserProfileAsync(ProfileDto profileDto);
    }
}
