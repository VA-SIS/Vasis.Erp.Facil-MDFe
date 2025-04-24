using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;

public class AuthTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthTests(WebApplicationFactory<Program> factory)
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
    public async Task RotaProtegida_ComToken_DeveRetornar200()
    {
        var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "admin@vasis.com",
            senha = "Admin123!"
        });

        var content = await loginResponse.Content.ReadFromJsonAsync<JsonElement>();
        var token = content.GetProperty("token").GetString();

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _client.GetAsync("/api/sistema/segredo");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
