using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.User;
using RockPaperScissorsApi.Controllers;

namespace RockPaperScissors.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserServiceWrapper _userService;

        public UserController(ILogger<AdminController> logger, IUserServiceWrapper userService) : base(logger)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Create(UserDto user)
        {
            await _userService.CreateAsync(user);

            return Ok(user);
        }
    }
}
