namespace AvBeacon.Domain.Entities;

public sealed class Applicant : User
{
    public Applicant(string email, string firstName, string lastName, string passwordHash)
        : base(email, firstName, lastName, passwordHash) { }

    public List<Education> Educations { get; init; } = new();
    public List<Experience> Experiences { get; init; } = new();
    public List<Skill> Skills { get; init; } = new();
    public List<JobApplication> JobApplications { get; init; } = new();
}