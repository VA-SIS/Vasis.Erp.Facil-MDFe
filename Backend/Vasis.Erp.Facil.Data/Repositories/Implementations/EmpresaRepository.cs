using System.Linq.Expressions;
using Vasis.Erp.Facil.Application.Dtos.Shared;
using Vasis.Erp.Facil.Data.Context;
using Vasis.Erp.Facil.Data.Repositories.Implementations.Base;
using Vasis.Erp.Facil.Data.Repositories.Interfaces;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Implementations
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Paginação sem filtro aplicado, equivalente a filtro "x => true".
        /// Facilita chamadas simples sem expressão lambda.
        /// </summary>
        public async Task<PagedResultDto<Empresa>> GetPagedAsync(PagedRequestDto request)
        {
            return await GetPagedAsync(x => true, request);
        }
    }
}
