using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces.Base;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<PagedResultDto<T>> GetPagedAsync(PagedRequestDto request)
        {
            var query = _dbSet.AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResultDto<T>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public virtual async Task<PagedResultDto<T>> GetPagedAsync(Expression<Func<T, bool>> predicate, PagedRequestDto request)
        {
            var query = _dbSet.Where(predicate);
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResultDto<T>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
