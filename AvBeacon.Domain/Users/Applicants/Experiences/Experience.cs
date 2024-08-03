using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Shared;

namespace AvBeacon.Domain.Users.Applicants.Experiences;

public sealed class Experience : Entity
{
    internal Experience(Applicant applicant, Title title, Description description, DateTime? start, DateTime? end)
        : base(Guid.NewGuid())
    {
        ApplicantId = applicant.Id;
        Title       = title;
        Description = description;
        Start       = start;
        End         = end;
    }

    public Guid ApplicantId { get; init; }
    public Title Title { get; set; }
    public Description Description { get; set; }
    public DateTime? Start { get; init; }
    public DateTime? End { get; set; }
}