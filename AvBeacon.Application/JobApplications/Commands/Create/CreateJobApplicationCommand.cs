using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.JobApplications.Commands.Create;

public sealed record CreateJobApplicationCommand(Guid ApplicantId, Guid JobOfferId) : ICommand<Result<Guid>>;