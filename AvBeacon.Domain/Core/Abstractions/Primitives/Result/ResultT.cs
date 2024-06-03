using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Domain.Core.Abstractions.Primitives.Result;

/// <summary>
///     Representa el resultado de alguna operación, con información de estado y posiblemente un valor y un error.
/// </summary>
/// <typeparam name="TValue">El tipo de valor del resultado.</typeparam>
public class Result<TValue> : _Core.Abstractions.Primitives.Result.Result
{
    private readonly TValue _value;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="Result{TValue}" /> con los parámetros especificados.
    /// </summary>
    /// <param name="value">El valor del resultado.</param>
    /// <param name="isSuccess">El indicador que muestra si el resultado es exitoso.</param>
    /// <param name="error">El error.</param>
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    /// <summary>
    ///     Obtiene el valor del resultado si el resultado es exitoso, de lo contrario, lanza una excepción.
    /// </summary>
    /// <returns>El valor del resultado si el resultado es exitoso.</returns>
    /// <exception cref="InvalidOperationException">cuando <see cref="Result.IsFailure" /> es verdadero.</exception>
    public TValue Value => IsSuccess
        ? _value
        : throw new InvalidOperationException("No se puede acceder al valor de un resultado fallido.");

    public static implicit operator Result<TValue>(TValue value)
    {
        return Success(value);
    }
}