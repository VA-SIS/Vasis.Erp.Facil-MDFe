using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Application.Services;
using Vasis.Erp.Facil.Shared.DTOs.Auth;

namespace Vasis.Erp.Facil.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly TokenService _tokenService;

        public AuthController(ApplicationDbContext dbContext, TokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var usuario = _dbContext.Usuarios
                .FirstOrDefault(u => u.Email == loginRequest.Email);

            if (usuario == null || usuario.Senha != loginRequest.Senha)
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            var token = _tokenService.GerarToken(usuario);

            return Ok(new LoginResponseDto
            {
                Token = token
            });
        }
    }
}
