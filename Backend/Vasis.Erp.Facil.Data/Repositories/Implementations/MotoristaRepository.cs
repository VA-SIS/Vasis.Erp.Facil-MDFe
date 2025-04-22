using Vasis.Erp.Facil.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Data.Context;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly ApplicationDbContext _context;

        public MotoristaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Motorista?> ObterPorIdAsync(Guid id)
        {
            return await _context.Motoristas.FindAsync(id);
        }

        public async Task<List<Motorista>> ListarAsync()
        {
            return await _context.Motoristas.ToListAsync();
        }

        public async Task AdicionarAsync(Motorista entity)
        {
            await _context.Motoristas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Motorista entity)
        {
            _context.Motoristas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                _context.Motoristas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
