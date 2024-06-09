namespace AvBeacon.Infrastructure.Migrations;

public class Education
{
    public Guid Id { get; set; }

    public string EducationType { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public Guid ApplicantId { get; set; }

    public virtual User Applicant { get; set; } = null!;
}