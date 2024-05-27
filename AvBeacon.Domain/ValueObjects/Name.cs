using AvBeacon.Domain.Core.Abstractions.Errors;
using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain.ValueObjects;

/// <summary>Representa el value object de tipo name.</summary>
public class Name : ValueObject
{
    /// <summary>Longitud máxima del name.</summary>
    public const int MaxLength = 100;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Name" />.</summary>
    /// <param name="value">El valor del name.</param>
    private Name(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor del name.</summary>
    public string Value { get; }

    public static Result<Name> Create(string name)
    {
        return string.IsNullOrWhiteSpace(name)
            ? Result.Failure<Name>(DomainErrors.Name.NullOrEmpty)
            : name.Length > MaxLength
                ? Result.Failure<Name>(DomainErrors.Name.LongerThanAllowed)
                : Result.Success(new Name(name));
    }

    public static implicit operator string(Name name)
    {
        return name.Value;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value;
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}