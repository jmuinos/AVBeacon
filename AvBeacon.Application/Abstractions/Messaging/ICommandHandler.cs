namespace AvBeacon.Application.Abstractions.Messaging;

//TODO: Qúe implica contravariant?
public interface ICommandHandler<in TCommand>
{
    //TODO: Definir  class "Result" y hacer que el método sea Task<Result> para que todos los comandos devuelvan un mismo tipo
    Task Handle(TCommand command, CancellationToken cancellationToken);
}