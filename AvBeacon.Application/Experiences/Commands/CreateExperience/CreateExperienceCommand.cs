using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.Experiences.Commands.CreateExperience;

public class CreateExperienceCommand(
    Guid applicantId,
    string? description,
    string? recruiterName,
    DateTime? start,
    DateTime? end,
    string title)
    : IRequest<Result<Guid>>
{
    public Guid ApplicantId { get; set; } = applicantId;
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public string? RecruiterName { get; set; } = recruiterName;
    public DateTime? Start { get; set; } = start;
    public DateTime? End { get; set; } = end;
}