using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Experiences.Commands.Create;

/// <summary> Representa el comando para crear una experiencia. </summary>
public sealed record CreateExperienceCommand(
    Guid ApplicantId,
    string Title,
    string Description,
    DateTime? Start,
    DateTime? End
) : ICommand<Result>;