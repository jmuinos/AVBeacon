using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Commands.Users.Recruiters.ProcessJobApplication;

/// <summary>
///     Representa el comando para procesar una solicitud de trabajo.
/// </summary>
public sealed record ProcessJobApplicationCommand(Guid JobApplicationId, string State) : ICommand<Result>;