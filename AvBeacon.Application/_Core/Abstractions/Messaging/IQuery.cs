using MediatR;

namespace AvBeacon.Application._Core.Abstractions.Messaging;

/// <summary> Representa la interfaz de consulta. </summary>
/// <typeparam name="TResponse"> El tipo de respuesta de la consulta. </typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse> { }