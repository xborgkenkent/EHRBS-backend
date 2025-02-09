using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EHRBS_backend.Domain.Entities;
using System.Text;
using EHRBS_backend.Application.Commands;
using EHRBS_backend.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EHRBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok("User registered successfully") : BadRequest("User registration failed");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return Unauthorized(response.Message);
            }

            // Store the token in an HTTP-only cookie
            Response.Cookies.Append("EHRBS_xdafga", response.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Ensure HTTPS is used
                SameSite = SameSiteMode.Strict, // Prevent CSRF attacks
                Expires = DateTime.UtcNow.AddHours(3)
            });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("private")]
        public IActionResult PrivateEndpoint()
        {
            return Ok("Only logged-in users can access this.");
        }
    }

}
