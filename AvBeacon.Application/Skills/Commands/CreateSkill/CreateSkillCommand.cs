using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.Skills.Commands.CreateSkill;

public class CreateSkillCommand(Guid applicantId, string name) : IRequest<Result<Guid>>
{
    public Guid ApplicantId { get; set; } = applicantId;
    public string Name { get; set; } = name;
}