using Vasis.Erp.Facil.Data.Context;

namespace Vasis.Erp.Facil.Data.Transactions;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync() => await _context.SaveChangesAsync();
    public void Rollback() { /* Log ou desfazer estado */ }
}
