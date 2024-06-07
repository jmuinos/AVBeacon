using AvBeacon.Application._Core.Abstractions.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace AvBeacon.Infrastructure;

internal sealed class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    // TODO Seguro que puedo evitar tener que instanciar el método así
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}