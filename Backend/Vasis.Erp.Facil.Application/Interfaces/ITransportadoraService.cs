using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Interfaces.Services;
public interface ITransportadoraService
{
    Task<TransportadoraDto> GetByIdAsync(Guid id);
    Task<TransportadoraDto> CreateAsync(TransportadoraDto dto);
    Task<TransportadoraDto> UpdateAsync(Guid id, TransportadoraDto dto);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto request);
}
