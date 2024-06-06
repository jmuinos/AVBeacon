namespace AvBeacon.Domain._Core.Abstractions.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity(Guid id) { Id = id; }

    protected Entity() { }

    public Guid Id { get; }

    public bool Equals(Entity? other) { return other != null && GetType() == other.GetType() && Id == other.Id; }

    public override bool Equals(object? obj) { return obj is Entity entity && Equals(entity); }

    public override int GetHashCode() { return Id.GetHashCode(); }

    public static bool operator ==(Entity? first, Entity? second) { return first?.Equals(second) ?? second is null; }

    public static bool operator !=(Entity? first, Entity? second) { return !(first == second); }
}