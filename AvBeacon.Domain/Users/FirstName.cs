using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Domain.Users;

/// <summary>
///     Represents the first name value object.
/// </summary>
public sealed class FirstName : ValueObject
{
    /// <summary>
    ///     The first name maximum length.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    ///     Initializes a new instance of the <see cref="FirstName" /> class.
    /// </summary>
    /// <param name="value"> The first name value. </param>
    private FirstName(string value)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the first name value.
    /// </summary>
    public string Value { get; }

    public static implicit operator string(FirstName firstName)
    {
        return firstName.Value;
    }

    /// <summary>
    ///     Creates a new <see cref="FirstName" /> instance based on the specified value.
    /// </summary>
    /// <param name="firstName"> The first name value. </param>
    /// <returns> The result of the first name creation process containing the first name or an error. </returns>
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