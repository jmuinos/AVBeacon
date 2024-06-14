using System.Reflection;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Domain._Core.Primitives;

/// <summary> Represents an enumeration type. </summary>
/// <typeparam name="TEnum"> The type of the enumeration. </typeparam>
public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>, IComparable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Lazy<Dictionary<int, TEnum>> EnumerationsDictionary =
        new(() => GetAllEnumerationOptions()
            .ToDictionary(item => item.Value));

    protected Enumeration(int value, string name)
    {
        Value = value;
        Name = name;
    }

    protected Enumeration()
    {
        Value = default;
        Name = string.Empty;
    }

    public int Value { get; }
    public string Name { get; private set; }

    protected static IReadOnlyCollection<TEnum> List =>
        EnumerationsDictionary.Value.Values
            .ToList();


    public int CompareTo(Enumeration<TEnum>? other) { return other is null ? 1 : Value.CompareTo(other.Value); }

    public bool Equals(Enumeration<TEnum>? other)
    {
        return other is not null
               && GetType() == other.GetType()
               && other.Value.Equals(Value);
    }

    public static Maybe<TEnum> FromValue(int value)
    {
        return EnumerationsDictionary.Value.TryGetValue(value, out var enumeration)
            ? Maybe<TEnum>.From(enumeration)
            : Maybe<TEnum>.None!;
    }

    public static bool ContainsValue(int value)
    {
        return EnumerationsDictionary.Value
            .ContainsKey(value);
    }

    public static bool operator ==(Enumeration<TEnum>? a, Enumeration<TEnum>? b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Enumeration<TEnum>? a, Enumeration<TEnum>? b) { return !(a == b); }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration<TEnum> otherValue)
            return false;

        return GetType() == obj.GetType() && otherValue.Value.Equals(Value);
    }

    public override int GetHashCode() { return Value.GetHashCode(); }

    private static IEnumerable<TEnum> GetAllEnumerationOptions()
    {
        var enumType = typeof(TEnum);

        var enumerationTypes =
            Assembly.GetAssembly(enumType)!
                .GetTypes()
                .Where(type => enumType.IsAssignableFrom(type));

        var enumerations = new List<TEnum>();

        foreach (var enumerationType in enumerationTypes)
        {
            var enumerationTypeOptions = GetFieldsOfType<TEnum>(enumerationType);
            enumerations.AddRange(enumerationTypeOptions);
        }

        return enumerations;
    }

    private static List<TFieldType> GetFieldsOfType<TFieldType>(Type type)
    {
        return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => type.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TFieldType)fieldInfo.GetValue(null)!)
            .ToList();
    }
}