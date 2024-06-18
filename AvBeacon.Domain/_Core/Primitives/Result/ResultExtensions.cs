namespace AvBeacon.Domain._Core.Primitives.Result
{
    /// <summary> Contiene métodos de extensión para la clase Result. </summary>
    public static class ResultExtensions
    {
        /// <summary> 
        /// Garantiza que el predicado especificado sea verdadero, de lo contrario, devuelve un resultado de falla con el error especificado.
        /// </summary>
        /// <typeparam name="T"> El tipo de resultado. </typeparam>
        /// <param name="result"> El resultado. </param>
        /// <param name="predicate"> El predicado. </param>
        /// <param name="error"> El error. </param>
        /// <returns>
        ///     El resultado exitoso si el predicado es verdadero y el resultado actual es un resultado exitoso, de lo contrario un resultado fallido.
        /// </returns>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Error error)
    {
        if (result.IsFailure) return result;
        return result.IsSuccess && predicate(result.Value) ? result : Result.Failure<T>(error);
    }

        /// <summary> 
        /// Mapea el valor del resultado a un nuevo valor basado en la función de mapeo especificada. 
        /// </summary>
        /// <typeparam name="TIn"> El tipo de resultado. </typeparam>
        /// <typeparam name="TOut"> El tipo de resultado de salida. </typeparam>
        /// <param name="result"> El resultado. </param>
        /// <param name="func"> La función de mapeo. </param>
        /// <returns>
        ///     El resultado exitoso con el valor mapeado si el resultado actual es un resultado exitoso, de lo contrario, un resultado fallido.
        /// </returns>
        public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func)
        {
            return result.IsSuccess ? Result.Success(func(result.Value)) : Result.Failure<TOut>(result.Error);
        }

        // /// <summary> 
        // /// Se vincula al resultado de la función y lo devuelve. 
        // /// </summary>
        // /// <typeparam name="TIn"> El tipo de resultado. </typeparam>
        // /// <param name="result"> El resultado. </param>
        // /// <param name="func"> La función de vinculación. </param>
        // /// <returns>
        // ///     El resultado exitoso con el valor vinculado si el resultado actual es un resultado exitoso, de lo contrario un resultado fallido.
        // /// </returns>
        // public static async Task<Result> Bind<TIn>(this Result<TIn> result, Func<TIn, Task<Result>> func)
        // {
        //     return result.IsSuccess ? await func(result.Value) : Result.Failure(result.Error);
        // }

        /// <summary> 
        /// Se vincula al resultado de la función y lo devuelve. 
        /// </summary>
        /// <typeparam name="TIn"> El tipo de resultado. </typeparam>
        /// <typeparam name="TOut"> El tipo de resultado de salida. </typeparam>
        /// <param name="result"> El resultado. </param>
        /// <param name="func"> La función de vinculación. </param>
        /// <returns>
        ///     El resultado exitoso con el valor vinculado si el resultado actual es un resultado exitoso, de lo contrario un resultado fallido.
        /// </returns>
        public static async Task<Result<TOut>> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<Result<TOut>>> func)
        {
            return result.IsSuccess ? await func(result.Value) : Result.Failure<TOut>(result.Error);
        }

        /// <summary> 
        /// Hace coincidir el estado de éxito del resultado con las funciones correspondientes. 
        /// </summary>
        /// <typeparam name="TIn"> El tipo de resultado. </typeparam>
        /// <typeparam name="TOut"> El tipo de resultado de salida. </typeparam>
        /// <param name="resultTask"> La tarea de resultado. </param>
        /// <param name="onSuccess"> La función en caso de éxito. </param>
        /// <param name="onFailure"> La función en caso de falla. </param>
        /// <returns>
        ///     El resultado de la función en caso de éxito si el resultado es un resultado exitoso, de lo contrario, el resultado de la función en caso de falla.
        /// </returns>
        public static async Task<TOut> Match<TIn, TOut>(this Task<Result<TIn>> resultTask, Func<TIn, TOut> onSuccess, Func<Error, TOut> onFailure)
        {
            var result = await resultTask;
            return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
        }
    }
}