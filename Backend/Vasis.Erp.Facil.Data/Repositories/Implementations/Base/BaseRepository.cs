using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Context;
using System.Linq.Expressions;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Dtos.Common;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Set<T>().AnyAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        // Ajuste da paginação
        public virtual async Task<PagedResultDto<T>> GetPagedAsync(Expression<Func<T, bool>> predicate, PagedRequestDto request)
        {
            var query = _context.Set<T>().Where(predicate);

            // Filtrando os dados com base no parâmetro Filter, se houver
            if (!string.IsNullOrEmpty(request.Filter))
            {
                query = query.Where(e => EF.Property<string>(e, "Name")!.Contains(request.Filter)); // Ajuste conforme o nome da propriedade a ser filtrada
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize) // Paginação com base em PageNumber e PageSize
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResultDto<T>(items, totalCount); // Retorna o resultado paginado
        }

        public Task<PagedResult<T>> GetPagedAsync(PagedRequestDto request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
