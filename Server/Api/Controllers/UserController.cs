﻿using Core.Kernel.Helper;
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

        [HttpPost("Signup")]
        public async Task<ActionResult> Signup(UserModel user)
        {
            var result = await _userService.SignupAsync(user.ToDto());

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserModel user)
        {
            await _userService.LoginAsync(user.UserName, user.Password.Decode());

            return Ok(user);
        }
    }
}
