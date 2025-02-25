using Core.Kernel.Service;
using RockPaperScissors.Model;

namespace RockPaperScissors.Repository.Dtos
{
    public class ProfileDto : DtoBase<long>
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; }
        public string? AlternateEmail { get; set; } = null;
        public string? PhoneNumber { get; set; }
    }

    public static class ProfileMapper
    {
        public static Profile? ToEntity(this ProfileDto? profileDto) =>
            profileDto is null
            ? null
            : new Profile
            {
                Key = profileDto.Key,
                FirstName = profileDto.FirstName,
                LastName = profileDto.LastName,
                Email = profileDto.Email,
                AlternateEmail = profileDto.AlternateEmail,
                PhoneNumber = profileDto.PhoneNumber
            };

        public static ProfileDto? ToDto(this Profile? profile) =>
            profile is null
            ? null
            : new ProfileDto
            {
                Key = profile.Key,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                AlternateEmail = profile.AlternateEmail,
                PhoneNumber = profile.PhoneNumber
            };
    }
}
