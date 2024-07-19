using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Maybe;

namespace AvBeacon.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    /// <summary> Obtiene la entidad con el identificador especificado. </summary>
    /// <param name="id"> El identificador de la entidad. </param>
    /// <returns> Una instancia de Maybe que puede contener la entidad con el identificador especificado. </returns>
    Task<Maybe<TEntity>> GetByIdAsync(Guid id);

    /// <summary> Inserta la entidad especificada en la base de datos. </summary>
    /// <param name="entity"> La entidad a insertar en la base de datos. </param>
    void Insert(TEntity entity);

    /// <summary> Inserta las entidades especificadas en la base de datos. </summary>
    /// <param name="entities"> Las entidades a insertar en la base de datos. </param>
    void InsertRange(IReadOnlyCollection<TEntity> entities);

    /// <summary> Actualiza la entidad especificada en la base de datos. </summary>
    /// <param name="entity"> La entidad a actualizar. </param>
    void Update(TEntity entity);

    /// <summary> Elimina la entidad especificada de la base de datos. </summary>
    /// <param name="entity"> La entidad a eliminar de la base de datos. </param>
    void Remove(TEntity entity);

    /// <summary> Obtiene todas las entidades. </summary>
    /// <returns> Una lista con todas las entidades. </returns>
    Task<List<TEntity>> GetAllAsync();
}