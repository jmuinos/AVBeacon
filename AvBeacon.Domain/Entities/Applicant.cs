using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Applicant : User
{
    private Applicant(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash) { }

    public List<JobApplication> JobApplications { get; } = new();
    public List<Education> Educations { get; } = new();
    public List<Experience> Experiences { get; } = new();
    public List<Skill> Skills { get; } = new();
    public List<ApplicantSkill> ApplicantSkills { get; } = new();

    public static Applicant Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Applicant(firstName, lastName, email, passwordHash);
    }
}