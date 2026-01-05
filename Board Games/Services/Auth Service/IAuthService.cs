using Board_Games.DTO_s.AuthDto_s;

namespace Board_Games.Services.Auth_Service
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
