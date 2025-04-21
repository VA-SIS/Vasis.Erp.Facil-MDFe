using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Implementations.Base;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Aqui você pode colocar métodos específicos de Empresa futuramente
    }
}
