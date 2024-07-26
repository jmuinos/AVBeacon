using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Recruiters
{
    /// <summary>Representa una oferta de trabajo.</summary>
    public class JobOffer : Entity
    {
        private JobOffer(Title title, Description description) : base(Guid.NewGuid())
        {
            Title = title;
            Description = description;
        }

        public Title Title { get; set; }
        public Description Description { get; set; }

// En JobOffer
        public Guid RecruiterId { get; init; }
        public Recruiter Recruiter { get; init; } = null!;
        public ICollection<JobApplication> JobApplications { get; private set; } = new List<JobApplication>();

        public static JobOffer Create(Title title, Description description) { return new JobOffer(title, description); }
    }
}