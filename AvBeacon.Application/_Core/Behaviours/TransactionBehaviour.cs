using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using MediatR;

namespace AvBeacon.Application._Core.Behaviours;

/// <summary> Representa el middleware de comportamiento de transacciones. </summary>
/// <typeparam name="TRequest">El tipo de solicitud.</typeparam>
/// <typeparam name="TResponse">El tipo de respuesta.</typeparam>
internal sealed class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary> Representa el middleware de comportamiento de transacciones. </summary>
    /// <typeparam name="TRequest">El tipo de solicitud.</typeparam>
    /// <typeparam name="TResponse">El tipo de respuesta.</typeparam>
    public TransactionBehaviour(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is IQuery<TResponse>) return await next();

        await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var response = await next();

            await transaction.CommitAsync(cancellationToken);

            return response;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }
}