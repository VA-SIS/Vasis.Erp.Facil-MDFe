using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Shared.Dtos.Common;

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<PagedResult<T>> GetPagedAsync(PagedRequestDto request, CancellationToken cancellationToken = default);
    }
}
