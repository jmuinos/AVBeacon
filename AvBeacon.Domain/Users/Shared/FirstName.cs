using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Domain.Users.Shared;

/// <summary>
///     Represents the user name value object.
/// </summary>
public sealed class FirstName : ValueObject
{
    /// <summary>
    ///     The firstname maximum length.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    ///     Initializes a new instance of the <see cref="FirstName" /> class.
    /// </summary>
    /// <param name="value"> The firstname value. </param>
    private FirstName(string value)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the user firstname value.
    /// </summary>
    public string Value { get; }

    public static implicit operator string(FirstName firstName)
    {
        return firstName.Value;
    }

    /// <summary>
    ///     Creates a new <see cref="FirstName" /> instance based on the specified value.
    /// </summary>
    /// <param name="firstName"> The firstname value. </param>
    /// <returns> The result of the firstname creation process containing the firstname or an error. </returns>
    public static Result<FirstName> Create(string firstName)
    {
        return Result.Create(firstName, DomainErrors.FirstNames.NullOrEmpty)
                     .Ensure(f => !string.IsNullOrWhiteSpace(f), DomainErrors.FirstNames.NullOrEmpty)
                     .Ensure(f => f.Length <= MaxLength, DomainErrors.FirstNames.LongerThanAllowed)
                     .Map(f => new FirstName(f));
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