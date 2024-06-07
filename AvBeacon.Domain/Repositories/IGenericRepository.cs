using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}