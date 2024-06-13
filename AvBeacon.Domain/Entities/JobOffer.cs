using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class JobOffer : Entity
{
    public JobOffer(Guid recruiterId, Title title, Description description)
        : base(Guid.NewGuid())
    {
        RecruiterId = recruiterId;
        Title = title;
        Description = description;
    }

    public Title Title { get; set; }
    public Description Description { get; set; }
    public Guid RecruiterId { get; init; }
    public Recruiter Recruiter { get; init; } = null!;
    public List<JobApplication> JobApplications { get; } = new();

    public static JobOffer Create(Guid recruiterId, Title title, Description description)
    {
        return new JobOffer(recruiterId, title, description);
    }
}