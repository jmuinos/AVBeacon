using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain.Shared;

/// <summary>Representa el value object de tipo description.</summary>
public sealed class Description : ValueObject
{
    /// <summary>Es la longitud máxima de la description.</summary>
    private const int MaxLength = 500;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Description" />.</summary>
    /// <param name="value"></param>
    private Description(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor de la description.</summary>
    public string Value { get; }

    public static Result<Description> Create(string description)
    {
        return string.IsNullOrWhiteSpace(description)
            ? Result.Failure<Description>(DomainErrors.Description.NullOrEmpty)
            : description.Length > MaxLength
                ? Result.Failure<Description>(DomainErrors.Description.LongerThanAllowed)
                : Result.Success(new Description(description));
    }

    public static implicit operator string(Description description)
    {
        return description.Value;
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