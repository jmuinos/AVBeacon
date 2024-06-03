using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain._Core.ValueObjects;

/// <summary>Representa el value object de tipo first name.</summary>
public sealed class FirstName : ValueObject
{
    /// <summary>Es la longitud máxima del first name.</summary>
    public const int MaxLength = 100;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="FirstName" />.</summary>
    /// <param name="value">El valor del first name.</param>
    private FirstName(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor del first name.</summary>
    public string Value { get; }

    public static Result<FirstName> Create(string firstName)
    {
        return string.IsNullOrWhiteSpace(firstName)
            ? Result.Failure<FirstName>(DomainErrors.FirstName.NullOrEmpty)
            : firstName.Length > MaxLength
                ? Result.Failure<FirstName>(DomainErrors.FirstName.LongerThanAllowed)
                : Result.Success(new FirstName(firstName));
    }

    public static implicit operator string(FirstName firstName)
    {
        return firstName.Value;
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