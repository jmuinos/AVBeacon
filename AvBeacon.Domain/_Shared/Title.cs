using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Domain._Shared;

/// <summary>
///     Represents the title value object.
/// </summary>
public class Title : ValueObject
{
    /// <summary>
    ///     The title maximum length.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Title" /> class.
    /// </summary>
    /// <param name="value"> The name value. </param>
    private Title(string value)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the title value.
    /// </summary>
    public string Value { get; }

    public static implicit operator string(Title title)
    {
        return title.Value;
    }

    /// <summary>
    ///     Creates a new <see cref="Title" /> instance based on the specified value.
    /// </summary>
    /// <param name="title"> The title value. </param>
    /// <returns> The result of the title creation process containing the title or an error. </returns>
    public static Result<Title> Create(string title)
    {
        return Result.Create(title, DomainErrors.Names.NullOrEmpty)
                     .Ensure(t => !string.IsNullOrWhiteSpace(t), DomainErrors.Names.NullOrEmpty)
                     .Ensure(t => t.Length <= MaxLength, DomainErrors.Names.LongerThanAllowed)
                     .Map(t => new Title(t));
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