using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.JobApplications.Commands.Process;

/// <summary> Representa el comando para procesar una solicitud de trabajo. </summary>
public sealed record ProcessJobApplicationCommand(Guid JobApplicationId, string State) : ICommand<Result>;