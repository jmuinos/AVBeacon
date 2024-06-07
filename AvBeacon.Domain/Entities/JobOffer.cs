using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Entities;

public sealed class JobOffer : Entity
{
    public JobOffer(Guid recruiterId, string title, string description)
        : base(Guid.NewGuid())
    {
        RecruiterId = recruiterId;
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public Guid RecruiterId { get; init; }
    public Recruiter Recruiter { get; init; } = null!;
    public List<JobApplication> JobApplications { get; init; } = [];
}