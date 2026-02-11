using Microsoft.AspNetCore.Mvc;
using WMS.API.Application.DTOs.Auth;
using WMS.API.Application.Interfaces;

namespace WMS.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }
    }
}
