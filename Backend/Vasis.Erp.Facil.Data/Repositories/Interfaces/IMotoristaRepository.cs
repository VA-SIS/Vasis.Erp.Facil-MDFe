using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces
{
    public interface IMotoristaRepository : IRepository<Motorista>
    {
        Task<Motorista?> GetByCpfAsync(string cpf);
    }
}
