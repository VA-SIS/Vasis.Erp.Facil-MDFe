using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<PagedResultDto<PessoaDto>> GetPagedAsync(PagedRequestDto request);
        Task<PessoaDto?> GetByIdAsync(Guid id);
        Task<PessoaDto> CreateAsync(PessoaDto dto);
        Task<PessoaDto?> UpdateAsync(PessoaDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
