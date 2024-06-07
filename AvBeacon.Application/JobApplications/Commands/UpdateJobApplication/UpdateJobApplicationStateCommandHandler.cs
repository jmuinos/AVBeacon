using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;
using MediatR;

namespace AvBeacon.Application.JobApplications.Commands.UpdateJobApplication;

public class UpdateJobApplicationStateCommandHandler(
    IJobApplicationRepository jobApplicationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateJobApplicationStateCommand, Result>
{
    public async Task<Result> Handle(UpdateJobApplicationStateCommand request, CancellationToken cancellationToken)
    {
        var jobApplication = await jobApplicationRepository.GetByIdAsync(request.JobApplicationId, cancellationToken);
        if (jobApplication == null) return Result.Failure(DomainErrors.JobApplication.NotFound);

        jobApplication.State = JobApplicationState.FromString(request.State);
        jobApplicationRepository.Update(jobApplication);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}