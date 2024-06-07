using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.JobApplications.Commands.CreateJobApplication;

public class CreateJobApplicationCommandHandler(
    IJobApplicationRepository jobApplicationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateJobApplicationCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var jobApplication = new JobApplication(request.ApplicantId, request.JobOfferId);

        await jobApplicationRepository.AddAsync(jobApplication, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(jobApplication.Id);
    }
}