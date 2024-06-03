using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain._Core.ValueObjects;

/// <summary>Representa el value object de tipo education type.</summary>
public sealed class EducationType : ValueObject
{
    public static readonly EducationType FormaciónProfesional = new("Formación Profesional");
    public static readonly EducationType GradoUniversitario = new("Grado Universitario");
    public static readonly EducationType Master = new("Máster");
    public static readonly EducationType Otra = new("Otra");
    public static readonly EducationType Ninguna = new("No especificada");

    public static readonly List<EducationType> All = [FormaciónProfesional, GradoUniversitario, Master, Otra, Ninguna];

    /// <summary>Inicializa una nueva instancia de la clase <see cref="EducationType" />.</summary>
    /// <param name="value">El valor del education type.</param>
    private EducationType(string value)
    {
        Value = value;
    }

    /// <summary>Obtiene el valor del education type.</summary>
    public string Value { get; }

    /// <summary>Obtiene el valor del education type buscándolo en función del value especificado.</summary>
    /// <param name="value">El valor del <see cref="EducationType" /> a buscar.</param>
    /// <returns>El valor del <see cref="EducationType" /> encontrado.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static EducationType Select(string value)
    {
        return All.FirstOrDefault(t => t.Value == value) ?? Ninguna;
    }

    public static implicit operator string(EducationType educationType)
    {
        return educationType.Value;
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

    /// <summary>Método para la deconstrucción.</summary>
    public static void Deconstruct(out EducationType formaciónProfesional, out EducationType gradoUniversitario,
        out EducationType master, out EducationType otra, out EducationType ninguna)
    {
        formaciónProfesional = FormaciónProfesional;
        gradoUniversitario = GradoUniversitario;
        master = Master;
        otra = Otra;
        ninguna = Ninguna;
    }
}