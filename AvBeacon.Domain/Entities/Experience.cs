using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Entities;

public sealed class Experience : Entity
{
    public Experience(string title, string? description, string? recruiterName, DateTime? start, DateTime? end,
        Guid applicantId)
        : base(Guid.NewGuid())
    {
        Title = title;
        Description = description;
        RecruiterName = recruiterName;
        Start = start;
        End = end;
        ApplicantId = applicantId;
    }

    public string Title { get; set; }
    public string? Description { get; set; }
    public string? RecruiterName { get; set; }
    public DateTime? Start { get; init; }
    public DateTime? End { get; set; }
    public Guid ApplicantId { get; init; }

    public Applicant Applicant { get; init; } = null!;
}