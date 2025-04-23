using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Application.Services.Implementations;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Implementations;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Data.Seed;
using Vasis.Erp.Facil.Shared.Dtos.Profiles;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddAutoMapper(typeof(EmpresaProfile));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    await DbSeeder.SeedAsync(context);
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
