using AvBeacon.Domain._Core.Primitives;
using FluentValidation.Results;

namespace AvBeacon.Application._Core.Exceptions;

/// <summary> Representa una excepción que ocurre cuando una validación falla. </summary>
public sealed class ValidationException : Exception
{
    /// <summary> Inicializa una nueva instancia de la clase <see cref="ValidationException" />. </summary>
    /// <param name="failures"> La colección de fallos de validación. </param>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation failures has occurred.")
    {
        Errors = failures
                .Distinct()
                .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage))
                .ToList();
    }

    /// <summary> Obtiene los errores de validación. </summary>
    public IReadOnlyCollection<Error> Errors { get; }
}