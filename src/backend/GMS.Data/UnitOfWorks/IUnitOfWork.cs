using Microsoft.EntityFrameworkCore.Storage;

namespace GMS.Data.UnitOfWorks;

public interface IUnitOfWork
{
    GMSDbContext Context { get; }

    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    void Dispose();
    Task RollbackTransactionAsync();
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
