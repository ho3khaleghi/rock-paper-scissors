using Core.Kernel.Helper;
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

        [HttpPost("Signup")]
        public async Task<ActionResult> Signup(SignupModel signup)
        {
            var result = await _userService.SignupAsync(signup.ToDto());

            return result.Data is not null ? Ok() : Conflict();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequestModel login)
        {
            var result = await _userService.LoginAsync(login.UserName, login.Password.Decode());

            if (result.Data is null) return Unauthorized("Invalid username or password.");

            return Ok(result.Data.ToLoginResponseModel());
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(UserModel user)
        {
            await _userService.LoginAsync(user.UserName, user.Password.Decode());

            return Ok(user);
        }
    }
}
