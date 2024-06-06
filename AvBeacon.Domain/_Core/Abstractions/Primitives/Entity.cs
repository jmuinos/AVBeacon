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

public sealed class Error : ValueObject
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    internal static Error None => new(string.Empty, string.Empty);

    public static implicit operator string(Error error) { return error.Code; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Message;
    }
}

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject? other)
    {
        return other != null && GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    protected abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? obj) { return obj is ValueObject valueObject && Equals(valueObject); }

    public override int GetHashCode() { return GetAtomicValues().Aggregate(default(int), HashCode.Combine); }
}