using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain.Shared;

/// <summary>Representa el value object de tipo title.</summary>
public sealed class Title : ValueObject
{
    /// <summary>Longitud máxima del title.</summary>
    private const int MaxLength = 80;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Title" />.</summary>
    /// <param name="value">El valor del title.</param>
    private Title(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor del title.</summary>
    public string Value { get; }

    public static Result<Title> Create(string title)
    {
        return string.IsNullOrWhiteSpace(title)
            ? Result.Failure<Title>(DomainErrors.Title.NullOrEmpty)
            : title.Length > MaxLength
                ? Result.Failure<Title>(DomainErrors.Title.LongerThanAllowed)
                : Result.Success(new Title(title));
    }

    public static implicit operator string(Title title)
    {
        return title.Value;
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