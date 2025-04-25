using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Application.Services;
using Vasis.Erp.Facil.Shared.DTOs.Auth;
using Vasis.Erp.Facil.Shared.Entities;

namespace Vasis.Erp.Facil.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest model)
    {
        if (model.Email == "admin@vasis.com" && model.Senha == "Admin123!")
        {
            var usuario = new Usuario
            {
                Id = Guid.Empty, // ou um Guid se for string
                Email = model.Email
            };

            var token = _tokenService.GerarToken(usuario);
            return Ok(new { token });
        }

        return Unauthorized("Usuário ou senha inválidos");
    }
}
