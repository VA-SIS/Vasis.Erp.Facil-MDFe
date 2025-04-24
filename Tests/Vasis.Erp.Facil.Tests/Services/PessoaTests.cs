using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;

public class PessoaTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PessoaTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();

        // Autenticar uma vez e usar o token
        var loginResponse = _client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "admin@vasis.com",
            senha = "Admin123!"
        }).Result;

        var content = loginResponse.Content.ReadFromJsonAsync<JsonElement>().Result;
        var token = content.GetProperty("token").GetString();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    [Fact]
    public async Task CriarPessoa_DadosValidos_DeveRetornar201()
    {
        var response = await _client.PostAsJsonAsync("/api/pessoa", new
        {
            Nome = "João da Silva",
            Documento = "12345678900"
        });

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task CriarPessoa_DadosInvalidos_DeveRetornar400()
    {
        var response = await _client.PostAsJsonAsync("/api/pessoa", new
        {
            Nome = "", // Nome vazio
            Documento = "123"
        });

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CriarPessoa_DadosNulos_DeveRetornar400()
    {
        var response = await _client.PostAsJsonAsync("/api/pessoa", new
        {
            Nome = (string)null,
            Documento = (string)null
        });

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
