namespace AvBeacon.Domain._Core.Abstractions.Primitives;

/// <summary>Representa la clase base de la que derivan todos los value objects.</summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <inheritdoc />
    public bool Equals(ValueObject? other) { return other is not null && AreValuesEqual(other); }

    /// <summary>Obtiene el valor atómico del value object.</summary>
    /// <returns>La colección de objetos representando los valores del value object.</returns>
    protected abstract IEnumerable<object> GetAtomicValues();

    private bool AreValuesEqual(ValueObject other)
    {
        return GetAtomicValues()
           .SequenceEqual(other.GetAtomicValues());
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) { return obj is ValueObject other && AreValuesEqual(other); }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return GetAtomicValues()
           .Aggregate(default(int), HashCode.Combine);
    }
}