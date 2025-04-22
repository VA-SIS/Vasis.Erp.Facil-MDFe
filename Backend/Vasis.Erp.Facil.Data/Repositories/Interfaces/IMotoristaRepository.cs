using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Domain.Repositories
{
    public interface IMotoristaRepository
    {
        Task<Motorista?> ObterPorIdAsync(Guid id);
        Task<List<Motorista>> ListarAsync();
        Task AdicionarAsync(Motorista entity);
        Task AtualizarAsync(Motorista entity);
        Task RemoverAsync(Guid id);
    }
}
