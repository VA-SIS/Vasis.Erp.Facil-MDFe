using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Domain.Repositories;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Veiculo?> ObterPorIdAsync(Guid id)
        {
            return await _context.Veiculos.FindAsync(id);
        }

        public async Task<List<Veiculo>> ListarAsync()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task AdicionarAsync(Veiculo entity)
        {
            await _context.Veiculos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Veiculo entity)
        {
            _context.Veiculos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                _context.Veiculos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
