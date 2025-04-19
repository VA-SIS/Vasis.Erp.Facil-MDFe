using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class MotoristaRepository : Repository<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Motorista?> GetByCpfAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.NumeroCpf == cpf);
        }
    }
}
