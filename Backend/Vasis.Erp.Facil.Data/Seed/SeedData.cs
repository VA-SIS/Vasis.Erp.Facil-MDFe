using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Shared.Entities;

namespace Vasis.Erp.Facil.Api.Infrastructure
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            // Garante que o banco foi criado
            _context.Database.EnsureCreated();

            // Verifica se já existe algum usuário administrador
            if (!_context.Usuarios.Any())
            {
                var admin = new Usuario
                {
                    Nome = "Administrador",
                    Email = "admin@vasis.com",
                    Senha = "Admin123!", // Idealmente, a senha deve ser criptografada
                    Ativo = true,
                    CriadoEm = DateTime.UtcNow
                };

                _context.Usuarios.Add(admin);
                _context.SaveChanges();
            }

            // Pode adicionar mais dados de exemplo aqui, como empresas, permissões etc.
        }
    }
}
