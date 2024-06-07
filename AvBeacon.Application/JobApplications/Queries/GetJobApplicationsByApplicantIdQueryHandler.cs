using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.JobApplications.Queries;

public class GetJobApplicationsByApplicantIdQueryHandler(
    IJobApplicationRepository jobApplicationRepository)
    : IRequestHandler<GetJobApplicationsByApplicantIdQuery, Result<List<JobApplication>>>
{
    public async Task<Result<List<JobApplication>>> Handle(GetJobApplicationsByApplicantIdQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplications =
            await jobApplicationRepository.GetByApplicantIdAsync(request.ApplicantId, cancellationToken);

        return Result.Success(jobApplications);
    }
}