using Core.Kernel.DataAccess.Repository;
using RockPaperScissors.Model;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public class ProfileRepository(IRepository repository) : IProfileRepository
    {
        public async Task<ProfileDto> CreateAsync(ProfileDto profile)
        {
            var entity = (profile.ToEntity() ?? throw new Exception("Profile cannot be null."))
                ?? throw new Exception("Profile entity cannot be null.");

            await repository.CreateAsync(entity);

            profile.Id = entity.Id;

            return profile;
        }

        public async Task<ProfileDto?> GetAsync(long id) => (await repository.GetAsync<Profile>(id)).ToDto();

        public async Task<ProfileDto> UpdateAsync(ProfileDto profile)
        {
            var entity = await repository.GetAsync<Profile>(profile.Id);

            entity.FirstName = profile.FirstName;
            entity.LastName = profile.LastName;
            entity.Email = profile.Email;
            entity.AlternateEmail = profile.AlternateEmail;
            entity.PhoneNumber = profile.PhoneNumber;

            await repository.UpdateAsync(entity);

            return entity.ToDto()!;
        }
    }
}
