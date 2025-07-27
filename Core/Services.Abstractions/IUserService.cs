using Shared.UserDtos;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
    }
}
