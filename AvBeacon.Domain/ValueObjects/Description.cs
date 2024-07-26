using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Domain.ValueObjects
{
    /// <summary> Represents the description value object. </summary>
    public sealed class Description : ValueObject
    {
        /// <summary> The description maximum length. </summary>
        public const int MaxLength = 400;

        /// <summary> Initializes a new instance of the <see cref="Description" /> class. </summary>
        /// <param name="value"> The description value. </param>
        private Description(string value) { Value = value; }

        /// <summary> Gets the description value. </summary>
        public string Value { get; }

        public static implicit operator string(Description description) { return description.Value; }

        /// <summary> Creates a new <see cref="Description" /> instance based on the specified value. </summary>
        /// <param name="description"> The description value. </param>
        /// <returns> The result of the description creation process containing the description or an error. </returns>
        public static Result<Description> Create(string description)
        {
            return Result.Create(description, DomainErrors.Description.NullOrEmpty)
                .Ensure(d => !string.IsNullOrWhiteSpace(d), DomainErrors.Description.NullOrEmpty)
                .Ensure(d => d.Length <= MaxLength, DomainErrors.Description.LongerThanAllowed)
                .Map(d => new Description(d));
        }

        /// <inheritdoc />
        public override string ToString() { return Value; }

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues() { yield return Value; }
    }
}