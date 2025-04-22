using Vasis.Erp.Facil.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Data.Context;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa?> ObterPorIdAsync(Guid id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<List<Pessoa>> ListarAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task AdicionarAsync(Pessoa entity)
        {
            await _context.Pessoas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Pessoa entity)
        {
            _context.Pessoas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await ObterPorIdAsync(id);
            if (entity != null)
            {
                _context.Pessoas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
