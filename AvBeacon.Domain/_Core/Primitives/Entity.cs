using AvBeacon.Domain._Core.Utility;

namespace AvBeacon.Domain._Core.Primitives;

/// <summary> Represents the base class that all entities derive from. </summary>
public abstract class Entity : IEquatable<Entity>
{
    protected Entity(Guid id) : this()
    {
        Ensure.NotEmpty(id, "The identifier is required.", nameof(id));
        Id = id;
    }

    protected Entity() { }

    public Guid Id { get; }

    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;
        return ReferenceEquals(this, other) || Id == other.Id;
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b) { return !(a == b); }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;
        if (!(obj is Entity other))
            return false;
        if (Id == Guid.Empty || other.Id == Guid.Empty)
            return false;

        return Id == other.Id;
    }

    /// <inheritdoc />
    public override int GetHashCode() { return Id.GetHashCode() * 41; }
}