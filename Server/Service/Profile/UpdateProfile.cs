using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile
{
    public class UpdateProfile(IProfileRepository profileRepository) : IUpdateProfile
    {
        public async Task<ProfileDto?> HandleAsync(ProfileDto request)
        {
            var profile = await profileRepository.GetAsync(request.Id);

            if (profile == null) return profile;

            profile.FirstName = request.FirstName;
            profile.LastName = request.LastName;
            profile.Email = request.Email;
            profile.AlternateEmail = request.AlternateEmail;
            profile.PhoneNumber = request.PhoneNumber;

            return await profileRepository.UpdateAsync(profile);
        }
    }
}
