using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Recruiters.Commands.UpdateRecruiter;

public class UpdateRecruiterCommandHandler(IRecruiterRepository recruiterRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateRecruiterCommand, Result>
{
    public async Task<Result> Handle(UpdateRecruiterCommand request, CancellationToken cancellationToken)
    {
        var recruiter = await recruiterRepository.GetByIdAsync(request.Id, cancellationToken);
        if (recruiter == null) return Result.Failure(DomainErrors.Recruiter.NotFound);

        if (!string.IsNullOrEmpty(request.FirstName) && !string.IsNullOrEmpty(request.LastName))
            recruiter.ChangeName(request.FirstName, request.LastName);

        recruiterRepository.Update(recruiter);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}