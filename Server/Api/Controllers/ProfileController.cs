
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Api.Models;
using RockPaperScissors.Service.Profile;

namespace RockPaperScissors.Api.Controllers
{
    public class ProfileController(ILogger<ProfileController> logger, IProfileServiceWrapper profileServiceWrapper) : ApiControllerBase(logger)
    {
        [Authorize]
        [HttpPost("Update")]
        public async Task<ActionResult> Update(ProfileModel profile)
        {
            var result = await profileServiceWrapper.UpdateAsync(profile.ToDto());
            return Ok(result);
        }
    }
}
