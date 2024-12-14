using Core.Kernel.Helper;
using Core.Kernel.Service;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Api.Models;
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

        [HttpPost("Create")]
        public async Task<ActionResult> Create(UserModel user)
        {
            await _userService.CreateAsync(user.ToDto());

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserModel user)
        {
            await _userService.LoginAsync(user.UserName, user.Password.Decode());

            return Ok(user);
        }
    }
}
