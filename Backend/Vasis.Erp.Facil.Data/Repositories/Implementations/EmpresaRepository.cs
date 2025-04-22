using System.Linq.Expressions;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Data.Repositories.Interfaces.Base;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class EmpresaRepository : IBaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Delegando os métodos genéricos para a classe base

        public new async Task<Empresa> AddAsync(Empresa entity)
        {
            return await base.AddAsync(entity);
        }

        public new async Task<List<Empresa>> FindAsync(Expression<Func<Empresa, bool>> predicate)
        {
            return await base.FindAsync(predicate);
        }

        public new async Task<List<Empresa>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public new async Task<Empresa?> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        public new async Task<Empresa> UpdateAsync(Empresa entity)
        {
            return await base.UpdateAsync(entity);
        }

        // Métodos específicos de Empresa podem ser adicionados aqui

        // Métodos herdados da interface IBaseRepository
        public new async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);  // Delegando a execução para a classe BaseRepository
        }

        public new async Task<bool> ExistsAsync(Guid id)
        {
            return await base.ExistsAsync(id);  // Delegando a execução para a classe BaseRepository
        }

        public new async Task<PagedResultDto<Empresa>> GetPagedAsync(Expression<Func<Empresa, bool>> predicate, PagedRequestDto request)
        {
            return await base.GetPagedAsync(predicate, request);  // Delegando a execução para a classe BaseRepository
        }
    }
}
