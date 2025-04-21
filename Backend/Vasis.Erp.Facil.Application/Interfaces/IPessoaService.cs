using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

public interface IPessoaService
{
    Task<PessoaDto> GetByIdAsync(Guid id);
    Task<PessoaDto> CreateAsync(PessoaDto dto);
    Task<PessoaDto> UpdateAsync(Guid id, PessoaDto dto);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<PessoaDto>> GetPagedAsync(PagedRequestDto request);
}
