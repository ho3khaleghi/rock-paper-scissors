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

        public async Task<IServiceResponse<UserDto?>> SignupAsync(SignupDto signupDto) =>
            await ServiceHandler.HandleAsync(async () => await _signupService.HandleAsync(signupDto));

        public Task<UserDto> DeleteAsync(int id) => throw new NotImplementedException();

        public Task<UserDto> GetAsync(int id) => throw new NotImplementedException();

        public Task<UserDto> GetAsync(string userName) => throw new NotImplementedException();

        public async Task<IServiceResponse<UserDto?>> LoginAsync(string? userName, byte[]? password) =>
            await ServiceHandler.HandleAsync(async () => await _loginService.HandleAsync(new UserDto { UserName = userName, Password = password }));

        public async Task<UserDto> LogoutAsync(UserDto userDto) => await _logoutService.HandleAsync(userDto);

        public Task<UserDto?> UpdateAsync(UserDto? userDto) => throw new NotImplementedException();
    }
}
