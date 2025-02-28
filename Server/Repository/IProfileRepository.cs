using Core.Kernel.Dependency;
using RockPaperScissors.Repository.Dtos;

namespace RockPaperScissors.Repository
{
    public interface IProfileRepository : IPerLifetimeScopeDependencyInjection
    {
        Task<ProfileDto?> GetAsync(long id);
        Task<ProfileDto> CreateAsync(ProfileDto profile);
        Task<ProfileDto> UpdateAsync(ProfileDto profile);
    }
}
