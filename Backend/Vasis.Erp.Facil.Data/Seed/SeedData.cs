using Vasis.Erp.Facil.Shared.Entities;
using Vasis.Erp.Facil.Data.Context;

namespace Vasis.Erp.Facil.Api.Infrastructure;

public class SeedData
{
    private readonly ApplicationDbContext _context;

    public SeedData(ApplicationDbContext context)
    {
        _context = context;
    }

    public void EnsureSeeded()
    {
        if (!_context.Usuarios.Any())
        {
            _context.Usuarios.Add(new Usuario
            {
                Nome = "Administrador",
                Email = "admin@vasis.com",
                Senha = BCrypt.Net.BCrypt.HashPassword("Admin123!")
            });

            _context.SaveChanges();
        }
    }
}
