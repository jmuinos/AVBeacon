using System.Reflection;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Maybe;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AvBeacon.Persistence
{
    public class AvBeaconDbContext : DbContext, IDbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public AvBeaconDbContext(DbContextOptions options, IMediator mediator)
            : base(options)
    {
        _mediator = mediator;
    }

        /// <inheritdoc />
        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

        /// <inheritdoc />
        public async Task<Maybe<TEntity>> GetByIdAsync<TEntity>(Guid id)
            where TEntity : Entity
    {
        if (id == Guid.Empty)
            return Maybe<TEntity>.None!;

        var entity = await Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        return entity == null ? Maybe<TEntity>.None! : Maybe<TEntity>.From(entity);
    }

        /// <inheritdoc />
        public void Insert<TEntity>(TEntity entity) where TEntity : Entity { Set<TEntity>().Add(entity); }

        /// <inheritdoc />
        public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities) where TEntity : Entity
    {
        Set<TEntity>().AddRange(entities);
    }

        /// <inheritdoc />
        public new void Remove<TEntity>(TEntity entity)
            where TEntity : Entity
    {
        Set<TEntity>().Remove(entity);
    }

        /// <inheritdoc />
        public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters,
            CancellationToken cancellationToken = default)
    {
        return Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

        /// <summary>Saves all of the pending changes in the unit of work.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of entities that have been saved.</returns>
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
}