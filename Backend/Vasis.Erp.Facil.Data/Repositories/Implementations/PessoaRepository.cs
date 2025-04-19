using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Pessoa>> BuscarPorNomeAsync(string nome)
        {
            return await _dbSet
                .Where(p => EF.Functions.Like(p.Nome, $"%{nome}%"))
                .ToListAsync();
        }
    }
}
