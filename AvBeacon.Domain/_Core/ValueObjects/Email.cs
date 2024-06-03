using System.Text.RegularExpressions;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain._Core.ValueObjects;

/// <summary>Representa el value object de tipo email.</summary>
public sealed class Email : ValueObject
{
    /// <summary>Longitud máxima del email.</summary>
    public const int MaxLength = 256;

    private const string EmailRegexPattern =
        @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

    private static readonly Lazy<Regex> EmailFormatRegex =
        new(() => new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Email" />.</summary>
    /// <param name="value">El valor del email.</param>
    private Email(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor del email.</summary>
    public string Value { get; }

    public static Result<Email> Create(string email)
    {
        return string.IsNullOrWhiteSpace(email)
            ? Result.Failure<Email>(DomainErrors.Email.NullOrEmpty)
            : email.Length > MaxLength
                ? Result.Failure<Email>(DomainErrors.Email.LongerThanAllowed)
                : !EmailFormatRegex.Value.IsMatch(email)
                    ? Result.Failure<Email>(DomainErrors.Email.InvalidFormat)
                    : Result.Success(new Email(email));
    }

    public static implicit operator string(Email email)
    {
        return email.Value;
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}