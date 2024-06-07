using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.Recruiters.Commands.UpdateRecruiter;

public class UpdateRecruiterCommand(Guid id, string? firstName, string? lastName)
    : IRequest<Result>
{
    public required Guid Id { get; init; } = id;
    public string? FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
}