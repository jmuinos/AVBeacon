namespace AvBeacon.Domain._Core.Abstractions.Primitives;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;

        var other = (ValueObject)obj;
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
           .Aggregate(0, (a, v) => HashCode.Combine(a, v));
    }

    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject? a, ValueObject? b) { return !(a == b); }
}