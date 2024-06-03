namespace AvBeacon.Application.Abstractions.Messaging;

//TODO: Qúe implica contravariant?
public interface ICommandHandler<in TCommand>
{
    Task Handle(TCommand command, CancellationToken cancellationToken);
}