using System.Reflection;
using AvBeacon.Application.Abstractions.Common;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Persistence.Extensions;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace AvBeacon.Persistence;

public class AvBeaconDbContext : DbContext, IDbContext, IUnitOfWork
{
    private readonly IDateTime _dateTime;

    public AvBeaconDbContext(DbContextOptions options, IDateTime dateTime, IMediator mediator)
        : base(options)
    {
        _dateTime = dateTime;
    }

    /// <inheritdoc />
    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

    /// <inheritdoc />
    public async Task<Maybe<TEntity>> GetByIdAsync<TEntity>(Guid id) where TEntity : Entity
    {
        return id == Guid.Empty
                   ? Maybe<TEntity>.None
                   : Maybe<TEntity>.From((await Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id))!);
    }

    /// <inheritdoc />
    public void Insert<TEntity>(TEntity entity) where TEntity : Entity
    {
        Set<TEntity>().Add(entity);
    }

    /// <inheritdoc />
    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities)
        where TEntity : Entity
    {
        Set<TEntity>().AddRange(entities);
    }

    /// <inheritdoc />
    public new void Remove<TEntity>(TEntity entity) where TEntity : Entity
    {
        Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc />
    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters,
        CancellationToken cancellationToken = default)
    {
        return Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

    /// <summary>
    ///     Saves all the pending changes in the unit of work.
    /// </summary>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> The number of entities that have been saved. </returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = _dateTime.UtcNow;
        UpdateAuditableEntities(utcNow);
        UpdateSoftDeletableEntities(utcNow);

        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return Database.BeginTransactionAsync(cancellationToken);
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyUtcDateTimeConverter();
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    ///     Updates the entities implementing <see cref="IAuditableEntity" /> interface.
    /// </summary>
    /// <param name="utcNow"> The current date and time in UTC format. </param>
    private void UpdateAuditableEntities(DateTime utcNow)
    {
        foreach (var entityEntry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entityEntry.State is EntityState.Added)
                entityEntry.Property(nameof(IAuditableEntity.CreatedOnUtc)).CurrentValue = utcNow;

            if (entityEntry.State is EntityState.Modified)
                entityEntry.Property(nameof(IAuditableEntity.ModifiedOnUtc)).CurrentValue = utcNow;
        }
    }

    /// <summary>
    ///     Updates the entities implementing <see cref="ISoftDeletableEntity" /> interface.
    /// </summary>
    /// <param name="utcNow"> The current date and time in UTC format. </param>
    private void UpdateSoftDeletableEntities(DateTime utcNow)
    {
        foreach (var entityEntry in ChangeTracker.Entries<ISoftDeletableEntity>())
        {
            if (entityEntry.State is not EntityState.Deleted)
                continue;

            entityEntry.Property(nameof(ISoftDeletableEntity.DeletedOnUtc)).CurrentValue = utcNow;
            entityEntry.Property(nameof(ISoftDeletableEntity.Deleted)).CurrentValue      = true;
            entityEntry.State                                                            = EntityState.Modified;

            UpdateDeletedEntityEntryReferencesToUnchanged(entityEntry);
        }
    }

    /// <summary>
    ///     Updates the specified entity entry's referenced entries in the deleted state to the modified state.
    ///     This method is recursive.
    /// </summary>
    /// <param name="entityEntry"> The entity entry. </param>
    private static void UpdateDeletedEntityEntryReferencesToUnchanged(EntityEntry entityEntry)
    {
        if (!entityEntry.References.Any())
            return;

        foreach (var referenceEntry in entityEntry.References.Where(
                     r => r.TargetEntry is { State: EntityState.Deleted }))
        {
            if (referenceEntry.TargetEntry is null)
                continue;
            referenceEntry.TargetEntry.State = EntityState.Unchanged;

            UpdateDeletedEntityEntryReferencesToUnchanged(referenceEntry.TargetEntry);
        }
    }
}