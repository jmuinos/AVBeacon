using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Experience : Entity
{
    public Experience(Guid applicantId, Title title, Description description, DateTime? start, DateTime? end)
        : base(Guid.NewGuid())
    {
        ApplicantId = applicantId;
        Title = title;
        Description = description;
        Start = start;
        End = end;
    }

    public Guid ApplicantId { get; init; }
    public Title Title { get; set; }
    public Description Description { get; set; }
    public DateTime? Start { get; init; }
    public DateTime? End { get; set; }

    public Applicant Applicant { get; init; } = null!;

    public static Experience Create(Guid applicantId, Title title, Description description, DateTime? start,
        DateTime? end)
    {
        return new Experience(applicantId, title, description, start, end);
    }
}