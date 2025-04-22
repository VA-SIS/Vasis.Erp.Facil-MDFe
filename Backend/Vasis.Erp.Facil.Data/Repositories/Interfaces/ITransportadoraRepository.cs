// ITransportadoraRepository.cs
using Vasis.Erp.Facil.Shared.Domain.Entities;

public interface ITransportadoraRepository
{
    Task<IEnumerable<Transportadora>> ListarAsync();
    Task<Transportadora?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Transportadora transportadora);
    Task AtualizarAsync(Transportadora transportadora);
    Task RemoverAsync(Guid id);
}
