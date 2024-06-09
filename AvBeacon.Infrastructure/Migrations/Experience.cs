namespace AvBeacon.Infrastructure.Migrations;

public class Experience
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? RecruiterName { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public Guid ApplicantId { get; set; }

    public virtual User Applicant { get; set; } = null!;
}