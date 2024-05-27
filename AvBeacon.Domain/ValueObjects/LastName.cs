using AvBeacon.Domain.Core.Abstractions.Errors;
using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain.ValueObjects;

/// <summary>Representa el value object de tipo last name.</summary>
public sealed class LastName : ValueObject
{
    /// <summary>Es la longitud máxima del last name.</summary>
    public const int MaxLength = 100;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="LastName" />.</summary>
    /// <param name="value">El valor del last name.</param>
    private LastName(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor del last name.</summary>
    public string Value { get; }


    public static Result<LastName> Create(string lastName)
    {
        return string.IsNullOrWhiteSpace(lastName) 
            ? Result.Failure<LastName>(DomainErrors.LastName.NullOrEmpty) 
            : lastName.Length > MaxLength 
                ? Result.Failure<LastName>(DomainErrors.LastName.LongerThanAllowed) 
                : Result.Success(new LastName(lastName));
    }

    public static implicit operator string(LastName lastName) => lastName.Value;

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