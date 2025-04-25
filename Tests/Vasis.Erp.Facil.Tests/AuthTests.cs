using System.Net.Http.Json;
using Vasis.Erp.Facil.Tests.Infrastructure;
using FluentAssertions;

namespace Vasis.Erp.Facil.Tests
{
    public class AuthTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Should_Authenticate_With_Valid_Credentials()
        {
            // Arrange
            var loginRequest = new
            {
                Email = "admin@vasis.com",
                Senha = "Admin123!"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

            // Assert
            response.EnsureSuccessStatusCode(); // Código 200 esperado
            var content = await response.Content.ReadFromJsonAsync<AuthResponse>();

            content.Should().NotBeNull();
            content!.Token.Should().NotBeNullOrEmpty();
        }

        private class AuthResponse
        {
            public string Token { get; set; }
        }
    }
}
