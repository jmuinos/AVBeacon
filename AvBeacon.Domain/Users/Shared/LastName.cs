using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Domain.Users.Shared;

/// <summary>
///     Represents the lastname value object.
/// </summary>
public sealed class LastName : ValueObject
{
    /// <summary>
    ///     The lastname maximum length.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    ///     Initializes a new instance of the <see cref="LastName" /> class.
    /// </summary>
    /// <param name="value"> The lastname value. </param>
    private LastName(string value)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the lastname value.
    /// </summary>
    public string Value { get; }

    public static implicit operator string(LastName lastName)
    {
        return lastName.Value;
    }

    /// <summary>
    ///     Creates a new <see cref="FirstName" /> instance based on the specified value.
    /// </summary>
    /// <param name="lastName"> The lastname value. </param>
    /// <returns> The result of the lastname creation process containing the lastname or an error. </returns>
    public static Result<LastName> Create(string lastName)
    {
        return Result.Create(lastName, DomainErrors.LastNames.NullOrEmpty)
                     .Ensure(l => !string.IsNullOrWhiteSpace(l), DomainErrors.LastNames.NullOrEmpty)
                     .Ensure(l => l.Length <= MaxLength, DomainErrors.LastNames.LongerThanAllowed)
                     .Map(l => new LastName(l));
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