using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.JobApplications.Commands.UpdateJobApplication;

public class UpdateJobApplicationStateCommand(Guid jobApplicationId, string state) : IRequest<Result>
{
    public Guid JobApplicationId { get; init; } = jobApplicationId;
    public string State { get; set; } = state;
}