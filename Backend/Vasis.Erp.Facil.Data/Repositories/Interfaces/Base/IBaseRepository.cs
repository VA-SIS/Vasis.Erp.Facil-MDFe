using System.Linq.Expressions;
using Vasis.Erp.Facil.Application.Dtos.Shared;

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<List<T>> GetAllAsync();

        // 🔹 Atual (sem filtro)
        Task<PagedResultDto<T>> GetPagedAsync(PagedRequestDto request);

        // 🔹 Futuro (com expressão)
        Task<PagedResultDto<T>> GetPagedAsync(Expression<Func<T, bool>> predicate, PagedRequestDto request);
    }
}
