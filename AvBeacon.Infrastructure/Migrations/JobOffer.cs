namespace AvBeacon.Infrastructure.Migrations;

public class JobOffer
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid RecruiterId { get; set; }

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    public virtual User Recruiter { get; set; } = null!;
}