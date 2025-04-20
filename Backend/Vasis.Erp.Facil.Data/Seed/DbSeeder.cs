using Bogus;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Seed;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Empresas.AnyAsync()) return; // Já populado?

        var faker = new Faker("pt_BR");

        var empresas = new Faker<Empresa>("pt_BR")
            .RuleFor(e => e.NomeFantasia, f => f.Company.CompanyName())
            .RuleFor(e => e.RazaoSocial, f => f.Company.CompanyName() + " LTDA")
            //.RuleFor(e => e.Cnpj, f => f.Company.Cnpj())
            .Generate(10);

        var pessoas = new Faker<Pessoa>("pt_BR")
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.Email())
            .Generate(20);

        var motoristas = new Faker<Motorista>("pt_BR")
            .RuleFor(m => m.Nome, f => f.Name.FullName())
            .RuleFor(m => m.NumeroCnh, f => f.Random.Replace("##########"))
            .Generate(10);

        var transportadoras = new Faker<Transportadora>("pt_BR")
            .RuleFor(t => t.NomeFantasia, f => f.Company.CompanyName())
            //.RuleFor(t => t.Cnpj, f => f.Company.Cnpj())
            .Generate(10);

        var veiculos = new Faker<Veiculo>("pt_BR")
            .RuleFor(v => v.Placa, f => f.Vehicle.Vin().Substring(0, 7).ToUpper())
            .RuleFor(v => v.Modelo, f => f.Vehicle.Model())
            .RuleFor(v => v.Marca, f => f.Vehicle.Manufacturer())
            .RuleFor(v => v.AnoFabricacao, f => f.Date.Past(10).Year)
            .Generate(20);

        await context.Empresas.AddRangeAsync(empresas);
        await context.Pessoas.AddRangeAsync(pessoas);
        //await context.Motoristas.AddRangeAsync(motoristas);
        await context.Transportadoras.AddRangeAsync(transportadoras);
        //await context.Veiculos.AddRangeAsync(veiculos);

        await context.SaveChangesAsync();
    }
}
