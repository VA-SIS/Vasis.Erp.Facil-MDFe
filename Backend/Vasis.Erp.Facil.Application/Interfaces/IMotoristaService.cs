using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Common;

namespace Vasis.Erp.Facil.Application.Interfaces.Services
{
    public interface IMotoristaService
    {
        Task<PagedResultDto<MotoristaDto>> GetPagedAsync(PagedRequestDto<MotoristaDto> request);
        Task<MotoristaDto> GetByIdAsync(Guid id);
        Task<MotoristaDto> CreateAsync(MotoristaDto dto);
        Task<MotoristaDto> UpdateAsync(Guid id, MotoristaDto dto);
        Task DeleteAsync(Guid id);
    }
}
