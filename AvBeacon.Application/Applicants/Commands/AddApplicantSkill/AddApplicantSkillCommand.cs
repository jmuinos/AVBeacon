using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Application.Applicants.Commands.AddApplicantSkill;

public sealed record AddApplicantSkillCommand(Guid ApplicantId, Guid SkillId) : ICommand<Result<Skill>>;