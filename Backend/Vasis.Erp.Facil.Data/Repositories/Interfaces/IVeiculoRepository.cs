using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        Task<Veiculo?> GetByPlacaAsync(string placa);
    }
}
