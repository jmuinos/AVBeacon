using AvBeacon.Domain._Core.Abstractions.Events;

namespace AvBeacon.Domain._Core.Abstractions.Primitives;

/// <summary>Representa la clase base de la que derivan todas las entidades.</summary>
public abstract class Entity : IEquatable<Entity>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Entity" />.</summary>
    /// <param name="id">El identificador de la entidad.</param>
    protected Entity(Guid id)
    {
        Id = id;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Entity" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    protected Entity()
    {
    }

    private Guid Id { get; }

    /// <inheritdoc />
    public bool Equals(Entity? other)
    {
        if (other is null) return false;

        if (other.GetType() != GetType()) return false;

        return other.Id == Id;
    }

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not Entity entity) return false;

        return entity.Id == Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}