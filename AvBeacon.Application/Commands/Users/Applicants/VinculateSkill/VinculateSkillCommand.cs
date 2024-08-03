using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Users.Applicants.Skills;

namespace AvBeacon.Application.Commands.Users.Applicants.VinculateSkill;

public sealed record VinculateSkillCommand(Guid ApplicantId, Guid SkillId) : ICommand<Result<Skill>>;