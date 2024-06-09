using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Applicants.Commands;

public class AddApplicantSkillCommandHandler(
    ISkillRepository skillRepository,
    IApplicantRepository applicantRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<AddApplicantSkillCommand, Result>
{
    public async Task<Result> Handle(AddApplicantSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = skillRepository.GetByIdAsync(request.SkillId, cancellationToken).Result;
        var applicant = applicantRepository.GetByIdAsync(request.ApplicantId, cancellationToken).Result;

        if (skill is null)
            return Result.Failure(DomainErrors.Skill.NotFound);

        if (applicant is null)
            return Result.Failure(DomainErrors.Applicant.NotFound);


        await applicantRepository.AddSkillAsync(request.ApplicantId, request.SkillId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(skill);
    }
}