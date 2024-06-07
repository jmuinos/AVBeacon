using AvBeacon.Application._Core.Abstractions.Messaging;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace AvBeacon.Application._Core.Behaviours;

/// <summary> Representa el middleware de comportamiento de validación. </summary>
/// <typeparam name="TRequest">El tipo de solicitud.</typeparam>
/// <typeparam name="TResponse">El tipo de respuesta.</typeparam>
internal sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="ValidationBehaviour{TRequest,TResponse}" />. </summary>
    /// <param name="validators">El validador para el tipo de solicitud actual.</param>
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) { _validators = validators; }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is IQuery<TResponse>) return await next();

        var context = new ValidationContext<TRequest>(request);

        List<ValidationFailure> failures = _validators
                                          .Select(v => v.Validate(context))
                                          .SelectMany(result => result.Errors)
                                          .Where(f => f != null)
                                          .ToList();

        if (failures.Count != 0) throw new ValidationException(failures);

        return await next();
    }
}