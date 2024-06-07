using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.ValueObjects;
using MediatR;

namespace AvBeacon.Application.Educations.Commands;

public class CreateEducationCommand(
    Guid applicantId,
    EducationType educationType,
    string description,
    DateTime start,
    DateTime end) : IRequest<Result<Guid>>
{
    public Guid ApplicantId { get; init; } = applicantId;
    public string Description { get; set; } = description;
    public required EducationType EducationType { get; init; } = educationType;
    public DateTime Start { get; set; } = start;
    public DateTime End { get; set; } = end;
}