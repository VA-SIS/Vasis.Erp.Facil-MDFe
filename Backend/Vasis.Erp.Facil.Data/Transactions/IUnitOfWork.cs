namespace Vasis.Erp.Facil.Data.Transactions;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Rollback(); // Implementação opcional dependendo do escopo
}
