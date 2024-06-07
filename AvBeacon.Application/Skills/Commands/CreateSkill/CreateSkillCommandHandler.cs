using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Skills.Commands.CreateSkill;

public class CreateSkillCommandHandler(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSkillCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(request.Name);

        await skillRepository.AddAsync(skill, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(skill.Id);
    }
}