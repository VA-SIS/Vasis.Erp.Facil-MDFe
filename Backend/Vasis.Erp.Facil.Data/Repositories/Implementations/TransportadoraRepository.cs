using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Implementations.Base;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class TransportadoraRepository : BaseRepository<Transportadora>, ITransportadoraRepository
    {
        public TransportadoraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
