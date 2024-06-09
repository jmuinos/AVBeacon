using MediatR;

namespace AvBeacon.Application._Core.Abstractions.Messaging;

/// <summary> Representa la interfaz de consulta. </summary>
/// <typeparam name="TQuery">El tipo de consulta.</typeparam>
/// <typeparam name="TResponse">El tipo de respuesta de la consulta.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> { }