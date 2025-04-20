using Vasis.Erp.Facil.Application.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using Vasis.Erp.Facil.Shared.Dtos.Common;

namespace Vasis.Erp.Facil.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> GetAllAsync();
        Task<Empresa?> GetByIdAsync(Guid id);
        Task AddAsync(Empresa empresa);
        Task UpdateAsync(Empresa empresa);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task GetPagedAsync(Func<object, bool> value, PagedRequestDto<EmpresaDto> request);
    }
}
