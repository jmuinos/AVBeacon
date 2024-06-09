namespace AvBeacon.Infrastructure.Migrations;

public class JobApplication
{
    public Guid Id { get; set; }

    public Guid ApplicantId { get; set; }

    public Guid JobOfferId { get; set; }

    public string State { get; set; } = null!;

    public virtual User Applicant { get; set; } = null!;

    public virtual JobOffer JobOffer { get; set; } = null!;
}