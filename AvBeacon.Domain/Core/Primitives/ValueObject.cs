﻿namespace AvBeacon.Domain.Core.Primitives
{
    /// <summary>Represents the base class all value objects derive from.</summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        /// <inheritdoc />
        public bool Equals(ValueObject? other)
        {
            return other is not null && GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }

        public static bool operator ==(ValueObject? a, ValueObject? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b) { return !(a == b); }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return obj is ValueObject valueObject
                   && GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            HashCode hashCode = default;

            foreach (var obj in GetAtomicValues()) hashCode.Add(obj);

            return hashCode.ToHashCode();
        }

        /// <summary>Gets the atomic values of the value object.</summary>
        /// <returns>The collection of objects representing the value object values.</returns>
        protected abstract IEnumerable<object> GetAtomicValues();
    }
}