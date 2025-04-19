using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Data.Repositories.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<IEnumerable<Pessoa>> BuscarPorNomeAsync(string nome);
    }
}
