using EHRBS_backend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EHRBS_backend.Infrastructure.Security
{
    public class JwtService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
        {
            _jwtOptions = jwtOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateJwtToken(User user)
        {
            if (string.IsNullOrWhiteSpace(_jwtOptions.Key) || _jwtOptions.Key.Length < 32)
            {
                throw new InvalidOperationException("JWT key must be at least 256 bits (32 characters).");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Prevent token replay
            };

            var token = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // Store token in session
            _httpContextAccessor.HttpContext.Session.SetString("JwtToken", tokenString);

            return tokenString;
        }

        public void Logout()
        {
            var context = _httpContextAccessor.HttpContext;

            if (context != null)
            {
                context.Response.Cookies.Delete("JwtToken");
            }
        }

    }
}
