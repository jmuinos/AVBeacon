using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Candidates;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Skills;
using AvBeacon.Infrastructure.Repositories;

namespace AvBeacon.Infrastructure;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public ICandidateRepository Candidates { get; } = new CandidateRepository(context);
    public IEducationRepository Educations { get; } = new EducationRepository(context);
    public IExperienceRepository Experiences { get; } = new ExperienceRepository(context);
    public ISkillRepository Skills { get; } = new SkillRepository(context);
    public IJobOfferRepository JobOffers { get; } = new JobOfferRepository(context);
    public IJobApplicationRepository JobApplications { get; } = new JobApplicationRepository(context);
    public IRecruiterRepository Recruiters { get; } = new RecruiterRepository(context);

    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() { context.Dispose(); }
}