using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Domain.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa?> ObterPorIdAsync(Guid id);
        Task<List<Pessoa>> ListarAsync();
        Task AdicionarAsync(Pessoa entity);
        Task AtualizarAsync(Pessoa entity);
        Task RemoverAsync(Guid id);
    }
}
