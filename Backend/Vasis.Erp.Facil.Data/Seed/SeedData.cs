using Microsoft.Extensions.DependencyInjection;

namespace Vasis.Erp.Facil.Backend.Data
{
    public static class SeedData
    {
        public static void EnsureSeedData(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Usuarios.Any(u => u.Email == "admin@vasis.com"))
            {
                var admin = new Usuario
                {
                    Nome = "Administrador",
                    Email = "admin@vasis.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    CriadoEm = DateTime.UtcNow,
                    Ativo = true,
                    // preencha outros campos obrigatórios se houver
                };

                context.Usuarios.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
