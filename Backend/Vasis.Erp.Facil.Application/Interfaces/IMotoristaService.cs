using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public interface IMotoristaService
{
    Task<MotoristaDto> GetByIdAsync(Guid id);
    Task<MotoristaDto> CreateAsync(MotoristaDto dto);
    Task<MotoristaDto> UpdateAsync(Guid id, MotoristaDto dto);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<MotoristaDto>> GetPagedAsync(PagedRequestDto request);
}
