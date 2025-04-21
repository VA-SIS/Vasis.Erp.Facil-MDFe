using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public interface ITransportadoraService
{
    Task<TransportadoraDto> GetByIdAsync(Guid id);
    Task<TransportadoraDto> CreateAsync(TransportadoraDto dto);
    Task<TransportadoraDto> UpdateAsync(Guid id, TransportadoraDto dto);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<TransportadoraDto>> GetPagedAsync(PagedRequestDto request);
}
