using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Implementations.Base;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Common;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class TransportadoraRepository : BaseRepository<Transportadora>, ITransportadoraRepository
    {
        public TransportadoraRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PagedResult<Transportadora>> GetPagedAsync(PagedRequestDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
