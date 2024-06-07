using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Applicants.Commands;

public class UpdateApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateApplicantCommand, Result>
{
    public async Task<Result> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
    {
        var applicant = await applicantRepository.GetByIdAsync(request.Id, cancellationToken);
        if (applicant == null) return Result.Failure(DomainErrors.Applicant.NotFound);

        if (!string.IsNullOrEmpty(request.FirstName) && !string.IsNullOrEmpty(request.LastName))
            applicant.ChangeName(request.FirstName, request.LastName);
        applicantRepository.Update(applicant);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}