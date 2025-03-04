using Core.Kernel.Service;
using RockPaperScissors.Repository.Dtos;
using RockPaperScissors.Service.User.Dto;

namespace RockPaperScissors.Service.User
{
    public class UserServiceWrapper : ServiceWrapper, IUserServiceWrapper
    {
        private readonly ISignupService _signupService;
        private readonly ILoginService _loginService;
        private readonly ILogoutService _logoutService;

        public UserServiceWrapper(IServiceHandler serviceHandler,
                           ISignupService signupService,
                           ILoginService loginService,
                           ILogoutService logoutService) : base(serviceHandler)
        {
            _signupService = signupService;
            _loginService = loginService;
            _logoutService = logoutService;
        }

        public Task<bool> CheckUserNameAsync(string userName) => throw new NotImplementedException();

        public async Task<ServiceResponse<UserDto>> SignupAsync(SignupDto signupDto)
        {
            var result = await ServiceHandler.HandleAsync<UserDto>(async () => await _signupService.HandleAsync(signupDto));

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

        public async Task<ServiceResponse<UserDto>> LoginAsync(string? userName, byte[]? password)
        {
            var result = await ServiceHandler.HandleAsync<UserDto>(async () => await _loginService.HandleAsync(new UserDto { UserName = userName, Password = password }));

            return new ServiceResponse<UserDto>
            {
                Data = (UserDto?)result.Data,
                Message = result.Message,
                StatusCode = result.StatusCode
            };
        }

        public async Task<UserDto> LogoutAsync(UserDto userDto) => await _logoutService.HandleAsync(userDto);

        public Task<UserDto?> UpdateAsync(UserDto? userDto) => throw new NotImplementedException();
    }
}
