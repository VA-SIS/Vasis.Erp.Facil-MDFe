// TransportadoraRepository.cs
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Shared.Domain.Entities;

public class TransportadoraRepository : ITransportadoraRepository
{
    private readonly ApplicationDbContext _context;

    public TransportadoraRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transportadora>> ListarAsync()
    {
        return await _context.Transportadoras.AsNoTracking().ToListAsync();
    }

    public async Task<Transportadora?> ObterPorIdAsync(Guid id)
    {
        return await _context.Transportadoras.FindAsync(id);
    }

    public async Task AdicionarAsync(Transportadora transportadora)
    {
        _context.Transportadoras.Add(transportadora);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Transportadora transportadora)
    {
        _context.Transportadoras.Update(transportadora);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var transportadora = await _context.Transportadoras.FindAsync(id);
        if (transportadora != null)
        {
            _context.Transportadoras.Remove(transportadora);
            await _context.SaveChangesAsync();
        }
    }
}
