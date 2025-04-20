using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Common;

namespace Vasis.Erp.Facil.Application.Interfaces
{
    public interface ITransportadoraService
    {
        Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto<TransportadoraDto> request);
        Task<TransportadoraDto> GetByIdAsync(Guid id);
        Task<TransportadoraDto> CreateAsync(TransportadoraDto dto);
        Task<TransportadoraDto> UpdateAsync(Guid id, TransportadoraDto dto);
        Task DeleteAsync(Guid id);
    }
}
