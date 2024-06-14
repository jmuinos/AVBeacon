using AvBeacon.Domain._Core.Primitives;
using FluentValidation;

namespace AvBeacon.Application._Core.Abstractions.Extensions;

/// <summary> Contiene métodos de extensión para Fluent Validation. </summary>
public static class FluentValidationExtensions
{
    /// <summary> Especifica un código y un mensaje de error personalizados </summary>
    /// <typeparam name="T"> El tipo que se está validando. </typeparam>
    /// <typeparam name="TProperty"> La propiedad que se está validando. </typeparam>
    /// <param name="rule"> La regla actual. </param>
    /// <param name="error"> El error a utilizar. </param>
    /// <remarks>
    ///     Este método utiliza FluentValidation para validar entradas. Para obtener más información sobre cómo especificar un
    ///     código de error personalizado, consulte
    ///     <see
    ///         cref="FluentValidation.DefaultValidatorOptions.WithErrorCode{T, TProperty}(FluentValidation.IRuleBuilderOptions{T, TProperty}, string)" />
    ///     .
    ///     <see
    ///         cref="FluentValidation.DefaultValidatorOptions.WithMessage{T, TProperty}(FluentValidation.IRuleBuilderOptions{T, TProperty}, string)" />
    ///     .
    /// </remarks>
    /// <returns> El mismo constructor de reglas. </returns>
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule, Error error)
    {
        if (error is null) throw new ArgumentNullException(nameof(error), "The error is required");

        return rule.WithErrorCode(error.Code).WithMessage(error.Message);
    }
}