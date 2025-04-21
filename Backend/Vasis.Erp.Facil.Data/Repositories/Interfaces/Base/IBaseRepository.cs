using System.Linq.Expressions;
using Vasis.Erp.Facil.Application.Dtos.Shared;   // <— aqui

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);

        // ==== Alinhado para usar PagedRequestDto ====
        Task<PagedResultDto<T>> GetPagedAsync(
            Expression<Func<T, bool>> predicate,
            PagedRequestDto request
        );
    }
}
