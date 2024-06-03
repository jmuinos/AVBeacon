namespace AvBeacon.Domain.Core.Abstractions.Primitives;

/// <summary>Representa un error concreto del domain.</summary>
public sealed class Error : ValueObject
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="Error" /></summary>
    /// <param name="code">El código de error.</param>
    /// <param name="message">El mensaje de error.</param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>Obtiene el código del error</summary>
    public string Code { get; }

    /// <summary>Obtiene el mensaje del error</summary>
    public string Message { get; }

    /// <summary>Obtiene la instancia de error vacío.</summary>
    internal static Error None => new(string.Empty, string.Empty);

    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Message;
    }
}