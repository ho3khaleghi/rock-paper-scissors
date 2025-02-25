using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Api.Models
{
    public class ProfileModel
    {
        public long Id { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; }
        public string? AlternateEmail { get; set; } = null;
        public string? PhoneNumber { get; set; }
    }

    public static class ProfileModelMapper
    {
        public static ProfileDto ToDto(this ProfileModel profile) =>
            new ()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                AlternateEmail = profile.AlternateEmail,
                PhoneNumber = profile.PhoneNumber
            };

        public static ProfileModel? ToModel(this ProfileDto? profile) =>
            profile is null
            ? null
            : new ProfileModel
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                AlternateEmail = profile.AlternateEmail,
                PhoneNumber = profile.PhoneNumber
            };
    }
}
