using AvBeacon.Domain._Core.Primitives;

namespace AvBeacon.Domain._Core.Exceptions;

/// <summary> Representa una excepción que ocurrió en el dominio. </summary>
public class DomainException : Exception
{
    /// <summary> Inicializa una nueva instancia de la clase <see cref="DomainException" />. </summary>
    /// <param name="error"> El error que contiene la información sobre lo que sucedió. </param>
    public DomainException(Error error)
        : base(error.Message)
    {
        Error = error;
    }

    /// <summary> Obtiene el error. </summary>
    public Error Error { get; }
}