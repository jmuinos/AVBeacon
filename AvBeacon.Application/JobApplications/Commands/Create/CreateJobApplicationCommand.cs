using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.JobApplications.Commands.Create
{
    public sealed record CreateJobApplicationCommand(Guid ApplicantId, Guid JobOfferId) : ICommand<Result<Guid>>;
}