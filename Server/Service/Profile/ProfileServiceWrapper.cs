using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile
{
    public class ProfileServiceWrapper : ServiceWrapper, IProfileServiceWrapper
    {
        private readonly IUpdateProfile _updateProfile;
        private readonly IGetUserProfileService _getUserProfileService;

        public ProfileServiceWrapper(IServiceHandler serviceHandler,
            IUpdateProfile updateProfile,
            IGetUserProfileService getUserProfileService) : base(serviceHandler)
        {
            _updateProfile = updateProfile;
            _getUserProfileService = getUserProfileService;
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

        public async Task<IServiceResponse<ProfileDto?>> GetUserProfileAsync(ProfileDto profileDto) =>
            await ServiceHandler.HandleAsync(async () => await _getUserProfileService.HandleAsync(profileDto));

    }
}
