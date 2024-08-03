using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Commands.Users.Applicants.CreateJobApplication;

public sealed record CreateJobApplicationCommand(Guid ApplicantId, Guid JobOfferId) : ICommand<Result<Guid>>;