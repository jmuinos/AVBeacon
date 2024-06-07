using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.JobApplications.Commands.CreateJobApplication;

public class CreateJobApplicationCommand(Guid applicantId, Guid jobOfferId) : IRequest<Result<Guid>>
{
    public Guid ApplicantId { get; set; } = applicantId;
    public Guid JobOfferId { get; set; } = jobOfferId;
}