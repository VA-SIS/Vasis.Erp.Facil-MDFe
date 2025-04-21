using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Application.Dtos.Shared;

public interface IEmpresaService
{
    Task<EmpresaDto> GetByIdAsync(Guid id);
    Task<EmpresaDto> CreateAsync(EmpresaDto dto);
    Task<EmpresaDto> UpdateAsync(Guid id, EmpresaDto dto);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<EmpresaDto>> GetPagedAsync(PagedRequestDto request);
}
