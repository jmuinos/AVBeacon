using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Maybe;
using AvBeacon.Domain.Repositories;
using AvBeacon.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories
{
    /// <summary> Represents the generic repository with the most common repository methods. </summary>
    /// <typeparam name="TEntity"> The entity type. </typeparam>
    internal abstract class GenericRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary> Initializes a new instance of the <see cref="GenericRepository{TEntity}" /> class. </summary>
        /// <param name="context"> The database context. </param>
        protected GenericRepository(IDbContext context) { Context = context; }

        /// <summary> Gets the database context. </summary>
        protected IDbContext Context { get; }

        /// <summary> Gets the entity with the specified identifier. </summary>
        /// <param name="id"> The entity identifier. </param>
        /// <returns> The maybe instance that may contain the entity with the specified identifier. </returns>
        public async Task<Maybe<TEntity>> GetByIdAsync(Guid id) { return await Context.GetByIdAsync<TEntity>(id); }

        /// <summary> Inserts the specified entity into the database. </summary>
        /// <param name="entity"> The entity to be inserted into the database. </param>
        public void Insert(TEntity entity) { Context.Insert(entity); }

        /// <summary> Inserts the specified entities to the database. </summary>
        /// <param name="entities"> The entities to be inserted into the database. </param>
        public void InsertRange(IReadOnlyCollection<TEntity> entities) { Context.InsertRange(entities); }

        /// <summary> Updates the specified entity in the database. </summary>
        /// <param name="entity"> The entity to be updated. </param>
        public void Update(TEntity entity) { Context.Set<TEntity>().Update(entity); }

        /// <summary> Removes the specified entity from the database. </summary>
        /// <param name="entity"> The entity to be removed from the database. </param>
        public void Remove(TEntity entity) { Context.Remove(entity); }

        public async Task<List<TEntity>> GetAllAsync() { return await Context.Set<TEntity>().ToListAsync(); }

        /// <summary> Checks if any entity meets the specified specification. </summary>
        /// <param name="specification"> The specification. </param>
        /// <returns> True if any entity meets the specified specification, otherwise false. </returns>
        public async Task<bool> AnyAsync(Specification<TEntity> specification)
    {
        return await Context.Set<TEntity>().AnyAsync(specification);
    }

        /// <summary> Gets the first entity that meets the specified specification. </summary>
        /// <param name="specification"> The specification. </param>
        /// <returns> The maybe instance that may contain the first entity that meets the specified specification. </returns>
        public async Task<Maybe<TEntity>> FirstOrDefaultAsync(Specification<TEntity> specification)
    {
        var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(specification);
        return entity is not null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }
    }
}