using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Interfaces.Services;
public interface IPessoaService
{
    Task<PessoaDto> GetByIdAsync(Guid id);
    Task<PessoaDto> CreateAsync(PessoaDto dto);
    Task<PessoaDto> UpdateAsync(Guid id, PessoaDto dto);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<PessoaDto>> GetPagedAsync(PagedRequestDto request);
}
