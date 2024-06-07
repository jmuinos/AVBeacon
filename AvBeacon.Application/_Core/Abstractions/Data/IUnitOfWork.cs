using Microsoft.EntityFrameworkCore.Storage;

namespace AvBeacon.Application._Core.Abstractions.Data;

public interface IUnitOfWork
{
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}