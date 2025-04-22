namespace Vasis.Erp.Facil.Application.Interfaces.Repositories;

using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Application.Dtos.Shared;

public interface ITransportadoraRepository
{
    Task<Transportadora?> GetByIdAsync(Guid id);
    Task<List<Transportadora>> GetAllAsync();
    Task<PagedResultDto<Transportadora>> GetPagedAsync(PagedRequestDto request);
    Task<Transportadora> CreateAsync(Transportadora transportadora);
    Task<Transportadora> UpdateAsync(Transportadora transportadora);
    Task DeleteAsync(Guid id);
}
