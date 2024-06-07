using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.Applicants.Commands;

public class UpdateApplicantCommand(Guid id, string? firstName, string? lastName)
    : IRequest<Result>
{
    public required Guid Id { get; init; } = id;
    public string? FirstName { get; } = firstName;
    public string? LastName { get; } = lastName;
}