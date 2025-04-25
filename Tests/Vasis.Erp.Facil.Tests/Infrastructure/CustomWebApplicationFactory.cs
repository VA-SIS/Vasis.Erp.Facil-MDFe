using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vasis.Erp.Facil.Api.Infrastructure;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Shared.Settings;
using System.Linq;

namespace Vasis.Erp.Facil.Tests.Infrastructure
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "JwtSettings:SecretKey", "chave-super-secreta-de-testes-1234567890" },
                    { "JwtSettings:Issuer", "TestIssuer" },
                    { "JwtSettings:Audience", "TestAudience" },
                    { "JwtSettings:ExpirationMinutes", "60" }
                });
            });

            builder.ConfigureServices(services =>
            {
                // Remove o contexto atual
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                // Adiciona o contexto com InMemory
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });

                // Configura JwtSettings manualmente
                services.AddSingleton(sp =>
                {
                    var config = sp.GetRequiredService<IConfiguration>();
                    var jwtSettings = new JwtSettings();
                    config.GetSection("JwtSettings").Bind(jwtSettings);
                    return jwtSettings;
                });

                // Build e execução do SeedData
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                    db.Database.EnsureCreated();

                    // Executa SeedData
                    var seeder = scopedServices.GetRequiredService<SeedData>();
                    seeder.Populate();
                }
            });
        }
    }
}
