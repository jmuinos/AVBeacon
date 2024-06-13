using System.Reflection;
using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AvBeacon.Persistence;

public class AvBeaconDbContext : DbContext, IDbContext, IUnitOfWork
{
    /// <summary> Initializes a new instance of the <see cref="AvBeaconDbContext" /> class. </summary>
    /// <param name="options"> The database context options. </param>
    public AvBeaconDbContext(DbContextOptions options) : base(options) { }

    /// <summary>
    ///     IMPORTANTE: Necesita su propio DbSet porque al representar una tabla intermedia de una relación many to many
    ///     NO TIENE ID PROPIO (podría hacerse, pero no sería un enfoque óptimo)
    /// </summary>
    public DbSet<ApplicantSkill> ApplicantSkills { get; set; }

    /// <inheritdoc />
    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity { return base.Set<TEntity>(); }

    /// <inheritdoc />
    public async Task<Maybe<TEntity>> GetBydIdAsync<TEntity>(Guid id) where TEntity : Entity
    {
        return id == Guid.Empty
                   ? Maybe<TEntity>.None!
                   : Maybe<TEntity>.From((await Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id))!);
    }

    /// <inheritdoc />
    public void Insert<TEntity>(TEntity entity) where TEntity : Entity { Set<TEntity>().Add(entity); }

    /// <inheritdoc />
    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities) where TEntity : Entity
    {
        Set<TEntity>().AddRange(entities);
    }

    /// <inheritdoc />
    public new void Remove<TEntity>(TEntity entity) where TEntity : Entity { Set<TEntity>().Remove(entity); }

    /// <inheritdoc />
    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters,
        CancellationToken cancellationToken = default)
    {
        return Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

    /// <summary> Saves all pending changes in the unit of work. </summary>
    /// <param name="cancellationToken"> The cancellation token. </param>
    /// <returns> The number of entities that have been saved. </returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
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

        base.OnModelCreating(modelBuilder);
    }
}