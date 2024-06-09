using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.JobApplications.Commands.CreateJobApplication;

public sealed record CreateJobApplicationCommand(Guid ApplicantId, Guid JobOfferId) : ICommand<Result<Guid>>;