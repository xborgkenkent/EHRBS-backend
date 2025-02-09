using EHRBS_backend.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace EHRBS_backend.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            _jwtService.Logout();
            return Ok(new { message = "Logged out successfully" });
        }
    }
}
