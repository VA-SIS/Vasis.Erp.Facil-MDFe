using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Common;

public interface IEmpresaService
{
    Task<PagedResultDto<EmpresaDto>> GetPagedAsync(PagedRequestDto<EmpresaDto> request);
    Task<EmpresaDto> GetByIdAsync(Guid id);
    Task<EmpresaDto> CreateAsync(EmpresaDto dto);
    Task<EmpresaDto> UpdateAsync(Guid id, EmpresaDto dto);
    Task DeleteAsync(Guid id);
}
