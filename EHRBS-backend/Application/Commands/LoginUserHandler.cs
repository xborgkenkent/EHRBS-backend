using MediatR;
using EHRBS_backend.Persistence.Interfaces;
using EHRBS_backend.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;
using EHRBS_backend.Infrastructure.Security;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly JwtService _jwtService;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public LoginUserHandler(JwtService jwtService, IUserRepository userRepository, IConfiguration configuration)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Find user by email
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        // Generate JWT token
        var token = _jwtService.GenerateJwtToken(user);
        return new AuthResponse { Success = true, Token = token, Message = "adasds" };
    }
}
