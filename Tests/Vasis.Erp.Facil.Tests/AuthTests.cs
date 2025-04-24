using FluentAssertions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;
using Vasis.Erp.Facil.Tests.Infrastructure; // <- aqui importa a factory customizada

namespace Vasis.Erp.Facil.Tests.Services;

public class AuthTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public AuthTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task RotaProtegida_SemToken_DeveRetornar401()
    {
        var response = await _client.GetAsync("/api/sistema/segredo");
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task RotaProtegida_ComTokenValido_DeveRetornar200()
    {
        var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "admin@vasis.com",
            senha = "Admin123!"
        });

       

        loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await loginResponse.Content.ReadFromJsonAsync<JsonElement>();
        content.TryGetProperty("token", out var tokenElement).Should().BeTrue();

        var token = tokenElement.GetString();
        token.Should().NotBeNullOrWhiteSpace();

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.GetAsync("/api/sistema/segredo");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Login_ComCredenciaisInvalidas_DeveRetornar401()
    {
        var loginData = new
        {
            email = "admin@vasis.com",
            senha = "senhaErrada"
        };

        var response = await _client.PostAsJsonAsync("/api/auth/login", loginData);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
