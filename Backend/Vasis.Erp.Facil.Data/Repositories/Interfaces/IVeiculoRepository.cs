using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Domain.Repositories
{
    public interface IVeiculoRepository
    {
        Task<Veiculo?> ObterPorIdAsync(Guid id);
        Task<List<Veiculo>> ListarAsync();
        Task AdicionarAsync(Veiculo entity);
        Task AtualizarAsync(Veiculo entity);
        Task RemoverAsync(Guid id);
    }
}
