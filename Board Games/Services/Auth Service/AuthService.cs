using Board_Games.DTO_s.AuthDto_s;
using Board_Games.Entities;
using Board_Games.Repos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Board_Games.Services.Auth_Service
{
    public class AuthService : IAuthService
    {

        private readonly IEfRepository<User> _userRepo;
        private readonly JwtService _jwt;

        public AuthService(IEfRepository<User> userRepo, JwtService jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.Query()
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null) return null;

            bool ok = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!ok) return null;

            return _jwt.GenerateToken(user);
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var exsting = await _userRepo.Query()
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (exsting != null) return false;

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();

            return true;    
        }
    }
}
