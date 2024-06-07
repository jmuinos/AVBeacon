using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using MediatR;

namespace AvBeacon.Application.JobApplications.Queries;

public class GetJobApplicationsByApplicantIdQuery : IRequest<Result<List<JobApplication>>>
{
    public Guid ApplicantId { get; set; }
}