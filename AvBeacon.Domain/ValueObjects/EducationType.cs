using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.ValueObjects;

public class EducationType : ValueObject
{
    public static readonly EducationType ObligatoryStudies = new("Obligatory Studies");
    public static readonly EducationType SuperiorStudies = new("Superior Studies");
    public static readonly EducationType MasterStudies = new("Master Studies");
    public static readonly EducationType OtherStudies = new("Other Studies");

    private EducationType(string value) { Value = value; }

    public string Value { get; }

    public override string ToString() { return Value; }

    protected override IEnumerable<object> GetAtomicValues() { yield return Value; }

    public static EducationType FromString(string value)
    {
        return value switch
        {
            "Obligatory Studies" => ObligatoryStudies,
            "Superior Studies"   => SuperiorStudies,
            "Master Studies"     => MasterStudies,
            "Other Studies"      => OtherStudies,
            _                    => throw new ArgumentException($"Invalid value: {value}", nameof(value))
        };
    }
}