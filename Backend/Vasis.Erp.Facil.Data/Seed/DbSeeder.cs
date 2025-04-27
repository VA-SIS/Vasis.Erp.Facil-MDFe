using Bogus;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.Empresas.AnyAsync())
                return;

            var empresas = new Faker<Empresa>("pt_BR")
                .RuleFor(e => e.NomeFantasia, f => f.Company.CompanyName())
                .RuleFor(e => e.RazaoSocial, f => f.Company.CompanyName() + " LTDA")
                .Generate(10);

            await context.Empresas.AddRangeAsync(empresas);
            await context.SaveChangesAsync();
        }
    }
}
