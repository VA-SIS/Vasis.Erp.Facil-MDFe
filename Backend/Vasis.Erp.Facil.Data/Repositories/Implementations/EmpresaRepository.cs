using System.Linq.Expressions;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Data.Repositories.Interfaces.Base;
using Vasis.Erp.Facil.Shared.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vasis.Erp.Facil.Data.Repositories.Implementations.Base;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Empresa> AddAsync(Empresa entity)
        {
            return await base.AddAsync(entity);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }

        public override async Task<bool> ExistsAsync(Guid id)
        {
            return await base.ExistsAsync(id);
        }

        public override async Task<List<Empresa>> FindAsync(Expression<Func<Empresa, bool>> predicate)
        {
            return await base.FindAsync(predicate);
        }

        public override async Task<List<Empresa>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public override async Task<Empresa?> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        public override async Task<PagedResultDto<Empresa>> GetPagedAsync(Expression<Func<Empresa, bool>> predicate, PagedRequestDto request)
        {
            return await base.GetPagedAsync(predicate, request);
        }

        public override async Task<Empresa> UpdateAsync(Empresa entity)
        {
            return await base.UpdateAsync(entity);
        }
    }
}
