using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Entities;

public static class SeedData
{
    public static void Inicializar(DbContext context)
    {
        if (!context.Set<Usuario>().Any())
        {
            context.Set<Usuario>().Add(new Usuario
            {
                Nome = "Administrador",
                Email = "admin@vasis.com",
                SenhaHash = BCrypt.Net.BCrypt.HashPassword("Admin123!")
            });

            context.SaveChanges();
        }
    }
}
