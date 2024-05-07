using AvBeacon.Domain.Interfaces.Repositories;

namespace AvBeacon.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICandidateRepository Candidates { get; }
    IEducationRepository Educations { get; }
    IExperienceRepository Experiences { get; }
    ISkillRepository Skills { get; }
    IJobOfferRepository JobOffers { get; }
    IJobApplicationRepository JobApplications { get; }
    IRecruiterRepository Recruiters { get; }

    Task<int> CompleteAsync();
}