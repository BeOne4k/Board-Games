using Board_Games.DTO_s.AuthDto_s;
using Board_Games.Services.Auth_Service;
using Microsoft.AspNetCore.Mvc;

namespace Board_Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _auth.RegisterAsync(dto);
            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _auth.LoginAsync(dto);
            if (token == null) return NotFound();

            return Ok(token);
        }
    }
}
