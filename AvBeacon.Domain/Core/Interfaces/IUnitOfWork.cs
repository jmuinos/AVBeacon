using AvBeacon.Domain.Core.Interfaces.Repositories;

namespace AvBeacon.Domain.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICandidateRepository Candidates { get; }
    IEducationRepository Educations { get; }
    IExperienceRepository Experiences { get; }
    ISkillRepository Skills { get; }
    IJobOfferRepository JobOffers { get; }
    IJobApplicationRepository JobApplications { get; }
    IRecruiterRepository Recruiters { get; }

    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
}