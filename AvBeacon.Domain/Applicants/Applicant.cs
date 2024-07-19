using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Applicants;

public sealed class Applicant : User
{
    private Applicant(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash) { }

    public ICollection<JobApplication> JobApplications { get; private set; } = new List<JobApplication>();
    public ICollection<Education> Educations { get; private set; } = new List<Education>();
    public ICollection<Experience> Experiences { get; private set; } = new List<Experience>();
    public ICollection<Skill> Skills { get; private set; } = new List<Skill>();


    public static Applicant Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Applicant(firstName, lastName, email, passwordHash);
    }
}