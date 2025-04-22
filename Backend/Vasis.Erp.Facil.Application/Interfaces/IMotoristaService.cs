using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Interfaces.Services
{
    public interface IMotoristaService
    {
        Task<PagedResultDto<MotoristaDto>> GetPagedAsync(PagedRequestDto request);
        Task<MotoristaDto> GetByIdAsync(Guid id);
        Task<MotoristaDto> CreateAsync(MotoristaDto dto);
        Task<MotoristaDto> UpdateAsync(Guid id, MotoristaDto dto);
        Task DeleteAsync(Guid id);
    }
}
