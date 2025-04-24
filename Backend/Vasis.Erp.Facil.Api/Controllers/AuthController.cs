using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vasis.Erp.Facil.Api.Settings;
using Vasis.Erp.Facil.Backend.Services;
using Vasis.Erp.Facil.Shared.Models;

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
            var token = _tokenService.GenerateToken(model.Email);
            return Ok(new { token });
        }

        return Unauthorized("Usuário ou senha inválidos");
    }
}
