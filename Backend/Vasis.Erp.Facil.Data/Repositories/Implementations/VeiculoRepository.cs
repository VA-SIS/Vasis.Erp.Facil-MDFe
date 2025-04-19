using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Veiculo?> GetByPlacaAsync(string placa)
        {
            return await _dbSet.FirstOrDefaultAsync(v => v.Placa == placa);
        }
    }
}
