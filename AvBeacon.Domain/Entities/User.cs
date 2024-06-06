using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Enumerables;

namespace AvBeacon.Domain.Entities
{
    public abstract class User : Entity
    {
        protected User(Guid id, string email, string firstName, string lastName) : base(id)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PasswordHash { get; private set; }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public bool VerifyPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            return passwordHasher.VerifyHashedPassword(this, PasswordHash, password) == PasswordVerificationResult.Success;
        }
    }

    public sealed class Applicant : User
    {
        public Applicant(Guid id, string email, string firstName, string lastName)
            : base(id, email, firstName, lastName)
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public Guid UserId { get; set; }
        public List<Education> Educations { get; set; } = new();
        public List<Experience> Experiences { get; set; } = new();
        public List<Skill> Skills { get; set; } = new();

        public void AddEducation(Education education) { Educations.Add(education); }

        public void RemoveEducation(Education education) { Educations.Remove(education); }

        public void AddExperience(Experience experience) { Experiences.Add(experience); }

        public void RemoveExperience(Experience experience) { Experiences.Remove(experience); }

        public void AddSkill(Skill skill) { Skills.Add(skill); }

        public void RemoveSkill(Skill skill) { Skills.Remove(skill); }

        public void UpdateDetails(string email, string firstName, string lastName)
        {
            Email = email ?? Email;
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
        }
    }

    public sealed class Recruiter : User
    {
        public Recruiter(Guid id, string email, string firstName, string lastName)
            : base(id, email, firstName, lastName)
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public Guid UserId { get; set; }
        public List<JobOffer> JobOffers { get; set; } = new();

        public void AddJobOffer(JobOffer jobOffer)
        {
            JobOffers.Add(jobOffer);
        }

        public void RemoveJobOffer(JobOffer jobOffer)
        {
            JobOffers.Remove(jobOffer);
        }
    }

    public sealed class JobOffer : Entity
    {
        public JobOffer(Guid id, Guid recruiterId, string title, string description)
            : base(id)
        {
            RecruiterId = recruiterId;
            Title = title;
            Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public Guid RecruiterId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int JobApplicationCount { get; private set; }

        // Propiedad de navegación a Recruiter
        public Recruiter Recruiter { get; set; } = null!;

        public void IncrementJobApplicationCount()
        {
            JobApplicationCount++;
        }

        public void DecrementJobApplicationCount()
        {
            JobApplicationCount--;
        }
    }

    public sealed class JobApplication : Entity
    {
        public JobApplication(Guid id, Guid applicantId, Guid jobOfferId, JobApplicationState state)
            : base(id)
        {
            ApplicantId = applicantId;
            JobOfferId = jobOfferId;
            State = state;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public Guid ApplicantId { get; private set; }
        public Guid JobOfferId { get; private set; }
        public JobApplicationState State { get; private set; }

        // Propiedad de navegación a Applicant
        public Applicant Applicant { get; set; } = null!;
        public JobOffer JobOffer { get; set; } = null!;
    }

    public sealed class Education : Entity
    {
        public Education(Guid id, EducationType educationType, string description, DateTime? start, DateTime? end)
            : base(id)
        {
            EducationType = educationType;
            Description = description;
            Start = start;
            End = end;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public EducationType EducationType { get; private set; }
        public string Description { get; private set; }
        public DateTime? Start { get; private set; }
        public DateTime? End { get; private set; }

        public Guid ApplicantId { get; set; }
    }

    public sealed class Experience : Entity
    {
        public Experience(Guid id, string title, string? description, string? recruiterName, DateTime? start, DateTime? end)
            : base(id)
        {
            Title = title;
            Description = description;
            RecruiterName = recruiterName;
            Start = start;
            End = end;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string? RecruiterName { get; private set; }
        public DateTime? Start { get; private set; }
        public DateTime? End { get; private set; }

        public Guid ApplicantId { get; set; }
    }

    public sealed class Skill : Entity
    {
        public Skill(Guid id, string name) : base(id)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public Guid ApplicantId { get; set; }
    }
}
