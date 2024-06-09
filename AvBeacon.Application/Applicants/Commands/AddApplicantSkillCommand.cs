using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Applicants.Commands;

public sealed record AddApplicantSkillCommand(Guid ApplicantId, Guid SkillId)
    : ICommand<Result>;