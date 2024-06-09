using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Experiences.Commands.CreateExperience;

public sealed record CreateExperienceCommand(
    Guid ApplicantId,
    string? Description,
    string? RecruiterName,
    DateTime? Start,
    DateTime? End,
    string Title)
    : ICommand<Result<Guid>>;