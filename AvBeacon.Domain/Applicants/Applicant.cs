using AvBeacon.Domain._Interfaces;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.Skills;

namespace AvBeacon.Domain.Applicants;

public sealed class Applicant(Guid id, string email, string firstName, string lastName)
    : User(id, email, firstName, lastName)
{
    public List<Education> Educations { get; } = new();
    public List<Experience> Experiences { get; } = new();
    public List<Skill> Skills { get; } = new();

    // Propiedad de navegación a JobApplications 
    public List<JobApplication> JobApplications { get; } = new();

    #region Métodos para manipular las colecciones

    public void AddEducation(Education education) { Educations.Add(education); }

    public void AddExperience(Experience experience) { Experiences.Add(experience); }

    public void AddSkill(Skill skill) { Skills.Add(skill); }

    public void AddJobApplication(JobApplication jobApplication) { JobApplications.Add(jobApplication); }

    public void RemoveEducation(Education education) { Educations.Remove(education); }

    public void RemoveExperience(Experience experience) { Experiences.Remove(experience); }

    public void RemoveSkill(Skill skill) { Skills.Remove(skill); }

    public void RemoveJobApplication(JobApplication jobApplication) { JobApplications.Remove(jobApplication); }

    #endregion

    public void UpdateDetails(string? requestEmail, string? requestFirstName, string? requestLastName) { throw new NotImplementedException(); }
}