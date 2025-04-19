using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Empresa?> GetByCnpjAsync(string cnpj)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Cnpj == cnpj);
        }
    }
}
