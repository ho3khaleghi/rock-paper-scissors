using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace RockPaperScissors.Service.User
{
    public class UserService : ServiceWrapper, IUserServiceWrapper
    {
        private readonly IUserSignupService _signupService;
        private readonly ILoginService _loginService;
        private readonly ILogoutService _logoutService;

        public UserService(IServiceHandler serviceHandler,
                           IUserSignupService signupService,
                           ILoginService loginService,
                           ILogoutService logoutService) : base(serviceHandler)
        {
            _signupService = signupService;
            _loginService = loginService;
            _logoutService = logoutService;
        }

        public Task<bool> CheckUserNameAsync(string userName) => throw new NotImplementedException();

        public async Task<ServiceResponse<UserDto>> SignupAsync(UserDto? userDto)
        {
            var result = await ServiceHandler.HandleAsync<UserDto>(async () => await _signupService.HandleAsync(userDto));

            return new ServiceResponse<UserDto>
            {
                Data = (UserDto?)result.Data,
                Message = result.Message,
                StatusCode = result.StatusCode
            };
        }

        public Task<UserDto> DeleteAsync(int id) => throw new NotImplementedException();

        public Task<UserDto> GetAsync(int id) => throw new NotImplementedException();

        public Task<UserDto> GetAsync(string userName) => throw new NotImplementedException();

        public async Task<UserDto?> LoginAsync(string? userName, byte[]? password) => await _loginService.HandleAsync(new UserDto { UserName = userName, Password = password });

        public async Task<UserDto> LogoutAsync(UserDto userDto) => await _logoutService.HandleAsync(userDto);

        public Task<UserDto?> UpdateAsync(UserDto? userDto) => throw new NotImplementedException();
    }
}
