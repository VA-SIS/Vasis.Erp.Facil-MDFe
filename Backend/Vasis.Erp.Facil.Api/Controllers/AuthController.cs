using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vasis.Erp.Facil.Api.Settings;

namespace Vasis.Erp.Facil.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            if (model.Email == "admin@vasis.com" && model.Senha == "Admin123!")
            {
                var token = GerarToken(model.Email);
                return Ok(new { Token = token });
            }

            return Unauthorized("Usuário ou senha inválidos");
        }

        private string GerarToken(string email)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
