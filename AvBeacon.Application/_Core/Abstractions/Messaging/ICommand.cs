using MediatR;

namespace AvBeacon.Application._Core.Abstractions.Messaging;

/// <summary> Representa la interfaz de comando. </summary>
/// <typeparam name="TResponse"> El tipo de respuesta del comando. </typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse> { }