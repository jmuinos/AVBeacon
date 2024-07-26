using AvBeacon.Domain.Core.Primitives;

namespace AvBeacon.Domain.Applicants
{
    /// <summary> Represents the education type enumeration. </summary>
    public sealed class EducationType : Enumeration<EducationType>
    {
        public static readonly EducationType Obligatory = new(0, "Obligatory Studies");
        public static readonly EducationType Superior = new(1, "Superior Studies");
        public static readonly EducationType Master = new(2, "Master Studies");
        public static readonly EducationType Other = new(3, "Other Studies");

        /// <summary> Initializes a new instance of the <see cref="EducationType" /> class. </summary>
        /// <param name="value"> The value. </param>
        /// <param name="name"> The name. </param>
        private EducationType(int value, string name) : base(value, name) { }

        /// <summary> Initializes a new instance of the <see cref="EducationType" /> class. </summary>
        /// <param name="value"> The value. </param>
        /// <remarks> Required by EF Core. </remarks>
        // private EducationType(int value) : base(value, FromValue(value).Value.Name) { }

        public static EducationType FromString(string value)
        {
            var educationType = List.FirstOrDefault(et => et.Name == value);
            if (educationType == null)
                throw new ArgumentException($"Invalid value: {value}", nameof(value));

            return educationType;
        }

        public static bool TryFromString(string value, out EducationType? educationType)
        {
            educationType = List.FirstOrDefault(et => et.Name == value);
            return educationType != null;
        }
    }
}