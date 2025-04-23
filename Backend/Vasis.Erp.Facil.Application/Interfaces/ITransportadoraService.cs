using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Application.Dtos.Transportadoras;

namespace Vasis.Erp.Facil.Application.Services.Interfaces
{
    public interface ITransportadoraService
    {
        Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto request);
        Task<TransportadoraDto?> GetByIdAsync(Guid id);
        Task<TransportadoraDto> CreateAsync(TransportadoraDto dto);
        Task<TransportadoraDto?> UpdateAsync(TransportadoraDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
