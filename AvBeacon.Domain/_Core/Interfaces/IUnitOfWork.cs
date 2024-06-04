using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Skills;

namespace AvBeacon.Domain._Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IApplicantRepository Applicants { get; }
    IEducationRepository Educations { get; }
    IExperienceRepository Experiences { get; }
    ISkillRepository Skills { get; }
    IJobOfferRepository JobOffers { get; }
    IJobApplicationRepository JobApplications { get; }
    IRecruiterRepository Recruiters { get; }

    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
}