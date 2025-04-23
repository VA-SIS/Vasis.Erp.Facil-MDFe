using Vasis.Erp.Facil.Application.Dtos.Motorista;
using Vasis.Erp.Facil.Application.Dtos.Shared;

namespace Vasis.Erp.Facil.Application.Services.Interfaces
{
    public interface IMotoristaService
    {
        Task<PagedResultDto<MotoristaDto>> GetPagedAsync(PagedRequestDto request);
        Task<MotoristaDto> GetByIdAsync(Guid id);
        Task<MotoristaDto> CreateAsync(MotoristaDto dto);
        Task<MotoristaDto> UpdateAsync(Guid id, MotoristaDto dto);
        Task DeleteAsync(Guid id);
        Task<List<MotoristaDto>> GetAllAsync();
    }
}
