namespace AvBeacon.Domain.Core.Abstractions.Primitives.Result;

/// <summary>
/// Representa el resultado de alguna operación, con información de estado y posiblemente un error.
/// </summary>
public class Result
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Result"/> con los parámetros especificados.
    /// </summary>
    /// <param name="isSuccess">El indicador que muestra si el resultado es exitoso.</param>
    /// <param name="error">El error.</param>
    protected Result(bool isSuccess, Error error)
    {
        switch (isSuccess)
        {
            case true when !error.Equals(Error.None):
                throw new InvalidOperationException();
            case false when error.Equals(Error.None):
                throw new InvalidOperationException();
            default:
                IsSuccess = isSuccess;
                Error = error;
                break;
        }
    }

    /// <summary>Obtiene un valor que indica si el resultado es exitoso.</summary>
    public bool IsSuccess { get; }

    /// <summary>Obtiene un valor que indica si el resultado es un fracaso.</summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>Obtiene el error.</summary>
    public Error Error { get; }

    /// <summary>Devuelve un <see cref="Result"/> exitoso.</summary>
    /// <returns>Una nueva instancia de <see cref="Result"/> con el indicador de éxito establecido.</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>Devuelve un <see cref="Result{TValue}"/> exitoso con el valor especificado.</summary>
    /// <typeparam name="TValue">El tipo de resultado.</typeparam>
    /// <param name="value">El valor del resultado.</param>
    /// <returns>Una nueva instancia de <see cref="Result{TValue}"/> con el indicador de éxito establecido.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    /// <summary>Crea un nuevo <see cref="Result{TValue}"/> con el valor nullable especificado y el error especificado.</summary>
    /// <typeparam name="TValue">El tipo de resultado.</typeparam>
    /// <param name="value">El valor del resultado.</param>
    /// <param name="error">El error en caso de que el valor sea nulo.</param>
    /// <returns>Una nueva instancia de <see cref="Result{TValue}"/> con el valor especificado o un error.</returns>
    public static Result<TValue> Create<TValue>(TValue value, Error error) 
        where TValue : class => 
        value is null ? Failure<TValue>(error) : Success(value);

    /// <summary>Devuelve un <see cref="Result"/> de fracaso con el error especificado.</summary>
    /// <param name="error">El error.</param>
    /// <returns>Una nueva instancia de <see cref="Result"/> con el error especificado y el indicador de fracaso establecido.</returns>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>Devuelve un <see cref="Result{TValue}"/> de fracaso con el error especificado.</summary>
    /// <typeparam name="TValue">El tipo de resultado.</typeparam>
    /// <param name="error">El error.</param>
    /// <returns>Una nueva instancia de <see cref="Result{TValue}"/> con el error especificado y el indicador de fracaso establecido.</returns>
    /// <remarks>
    /// Se ignora deliberadamente la asignación nullable aquí porque la API nunca permitirá que se acceda a ella.
    /// Al valor se accede a través de un método que lanzará una excepción si el resultado es un fracaso.
    /// </remarks>
    public static Result<TValue> Failure<TValue>(Error error) => new(default!, false, error);

    /// <summary>
    /// Devuelve el primer fracaso de los resultados especificados <paramref name="results"/>.
    /// Si no hay fracaso, se devuelve un éxito.
    /// </summary>
    /// <param name="results">El array de resultados.</param>
    /// <returns>
    /// El primer fracaso del array especificado <paramref name="results"/>, o un éxito si no existe.
    /// </returns>
    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.IsFailure) { return result; }
        }

        return Success();
    }
}
