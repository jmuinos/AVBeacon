using MediatR;

namespace AvBeacon.Application._Core.Abstractions.Messaging;

/// <summary> Representa la interfaz del manejador de comandos. </summary>
/// <typeparam name="TCommand"> El tipo de comando. </typeparam>
/// <typeparam name="TResponse"> El tipo de respuesta del comando. </typeparam>
public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> { }