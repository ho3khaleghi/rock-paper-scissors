using RockPaperScissors.Repository;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Service.Profile;

public class GetUserProfileService(IProfileRepository profileRepository) : IGetUserProfileService
{
    public async Task<ProfileDto?> HandleAsync(ProfileDto request)
    {
        var profile = await profileRepository.GetAsync(request.Id);
        
        return profile;
    }
}