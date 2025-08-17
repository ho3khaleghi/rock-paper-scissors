using Core.Kernel.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Api.Models;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.Profile;
using RockPaperScissors.Service.User;
using RockPaperScissorsApi.Controllers;

namespace RockPaperScissors.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserServiceWrapper _userService;
        private readonly IProfileServiceWrapper _profileService;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<AdminController> logger,
            IUserServiceWrapper userService,
            IProfileServiceWrapper profileService,
            IConfiguration configuration) : base(logger)
        {
            _userService = userService;
            _profileService = profileService;
            _configuration = configuration;
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

            if (result.Data is null || result.Data.AccessToken is null)
                return Unauthorized("Invalid username or password.");

            if (result.Data.RefreshToken is not null)
            {
                HttpContext.Response.Cookies.Append("refresh_token",
                    result.Data.RefreshToken!,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddDays(
                            int.Parse(_configuration["JwtSettings:RefreshTokenExpirationDays"]!))
                    });
            }

            return Ok(result.Data.ToLoginResponseModel());
        }

        [HttpPost("Refresh")]
        public async Task<ActionResult> Refresh()
        {
            var refreshToken = HttpContext.Request.Cookies["refresh_token"];
            if (refreshToken is null) return Unauthorized("Refresh token is required.");

            var result = await _userService.ValidateRefreshTokenAsync(refreshToken);
            if (result.Data is null || result.Data.AccessToken is null) return Unauthorized("Invalid refresh token.");
            if (result.Data.RefreshToken is not null)
            {
                HttpContext.Response.Cookies.Append("refresh_token",
                    result.Data.RefreshToken!,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddDays(
                            int.Parse(_configuration["JwtSettings:RefreshTokenExpirationDays"]!))
                    });
            }

            return Ok(result.Data.ToLoginResponseModel());
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel request)
        {
            var result = await _userService.ChangePasswordAsync(request.ToDto());

            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUserProfile")]
        public async Task<ActionResult> GetUserProfile(long id)
        {
            var profile = await _profileService.GetUserProfileAsync(new ProfileDto { Id = id });

            return Ok(profile);
        }
    }
}