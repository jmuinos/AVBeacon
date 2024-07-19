using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.Applicants.Commands.AddApplicantSkill;

public sealed record AddApplicantSkillCommand(Guid ApplicantId, Guid SkillId) : ICommand<Result<Skill>>;