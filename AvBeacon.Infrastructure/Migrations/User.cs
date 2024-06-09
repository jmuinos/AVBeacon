namespace AvBeacon.Infrastructure.Migrations;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}