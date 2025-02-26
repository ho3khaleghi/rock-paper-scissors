using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile
{
    public class ProfileServiceWrapper : ServiceWrapper, IProfileServiceWrapper
    {
        private readonly IUpdateProfile _updateProfile;

        public ProfileServiceWrapper(IServiceHandler serviceHandler, IUpdateProfile updateProfile) : base(serviceHandler)
        {
            _updateProfile = updateProfile;
        }

        public async Task<ServiceResponse<ProfileDto?>> UpdateAsync(ProfileDto profileDto)
        {
            var result = await ServiceHandler.HandleAsync<ProfileDto>(async () => await _updateProfile.HandleAsync(profileDto));

            return new ServiceResponse<ProfileDto?>
            {
                Data = (ProfileDto?)result.Data,
                Message = result.Message,
                StatusCode = result.StatusCode
            };
        }
    }
}
