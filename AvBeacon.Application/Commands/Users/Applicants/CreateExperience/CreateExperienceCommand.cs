using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Commands.Users.Applicants.CreateExperience;

/// <summary>
///     Representa el comando para crear una experiencia.
/// </summary>
public sealed record CreateExperienceCommand(
    Guid ApplicantId,
    string Title,
    string Description,
    DateTime? Start,
    DateTime? End
) : ICommand<Result>;