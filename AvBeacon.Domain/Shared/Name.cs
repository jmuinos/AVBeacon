using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain.Shared;

/// <summary>Representa el value object de tipo name.</summary>
public sealed class Name : ValueObject
{
    /// <summary>Longitud máxima del name.</summary>
    private const int MaxLength = 80;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Name" /></summary>
    /// <param name="value">El valor del name.</param>
    private Name(string value) { Value = value; }

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

    public static implicit operator string(Name name) { return name.Value; }

    /// <inheritdoc />
    public override string ToString() { return Value; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues() { yield return Value; }
}