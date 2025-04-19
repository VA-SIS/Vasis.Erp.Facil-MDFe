using System.Linq.Expressions;
using Vasis.Erp.Facil.Shared.Dtos.Common;


namespace Vasis.Erp.Facil.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

        //Task<PagedResultDto<T>> GetPagedAsync(
        //    Expression<Func<T, bool>> filter,
        //    PagedRequestDto<T> request); // Fixed CS0305 by adding the required type argument <T>

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
