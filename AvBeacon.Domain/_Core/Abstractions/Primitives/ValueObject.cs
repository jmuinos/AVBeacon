namespace AvBeacon.Domain._Core.Abstractions.Primitives;

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