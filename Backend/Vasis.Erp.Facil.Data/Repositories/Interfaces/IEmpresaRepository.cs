using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Empresa?> GetByCnpjAsync(string cnpj);
    }
}
