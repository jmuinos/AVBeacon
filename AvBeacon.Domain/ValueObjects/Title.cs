using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Domain.ValueObjects;

/// <summary> Represents the name value object. </summary>
public class Title : ValueObject
{
    /// <summary> The name maximum length. </summary>
    public const int MaxLength = 100;

    /// <summary> Initializes a new instance of the <see cref="Title" /> class. </summary>
    /// <param name="value"> The name value. </param>
    private Title(string value) { Value = value; }

    /// <summary> Gets the name value. </summary>
    public string Value { get; }

    public static implicit operator string(Title title) { return title.Value; }

    /// <summary> Creates a new <see cref="Title" /> instance based on the specified value. </summary>
    /// <param name="name"> The name value. </param>
    /// <returns> The result of the name creation process containing the name or an error. </returns>
    public static Result<Title> Create(string name)
    {
        return Result.Create(name, DomainErrors.Name.NullOrEmpty)
            .Ensure(n => !string.IsNullOrWhiteSpace(n), DomainErrors.Name.NullOrEmpty)
            .Ensure(n => n.Length <= MaxLength, DomainErrors.Name.LongerThanAllowed)
            .Map(f => new Title(f));
    }

    /// <inheritdoc />
    public override string ToString() { return Value; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues() { yield return Value; }
}