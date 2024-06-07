using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.ValueObjects;

public class JobApplicationState : ValueObject
{
    public static readonly JobApplicationState Sent = new("Sent");
    public static readonly JobApplicationState Accepted = new("Accepted");
    public static readonly JobApplicationState Denied = new("Denied");

    private JobApplicationState(string value) { Value = value; }

    public string Value { get; }

    public override string ToString() { return Value; }

    protected override IEnumerable<object> GetAtomicValues() { yield return Value; }

    public static JobApplicationState FromString(string value)
    {
        return value switch
        {
            "Accepted" => Accepted,
            "Denied"   => Denied,
            "Sent"     => Sent,
            _          => throw new ArgumentException($"Invalid value: {value}", nameof(value))
        };
    }
}