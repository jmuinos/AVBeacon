using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface ISkillRepository : IGenericRepository<Skill>
{
    Task<List<Skill>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}

public interface IRecruiterRepository : IGenericRepository<Recruiter>
{
    Task<Recruiter?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<Recruiter>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}

public interface IJobOfferRepository : IGenericRepository<JobOffer>
{
    Task<List<JobOffer>> SearchByTitleAsync(string titleText, CancellationToken cancellationToken = default);
}

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
    Task<List<JobApplication>> GetByApplicantNameAsync(string nameText, CancellationToken cancellationToken = default);
}

public interface IExperienceRepository : IGenericRepository<Experience>
{
    Task<List<Experience>> SearchByTitleAsync(string titleText, CancellationToken cancellationToken = default);
}

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<List<Education>> SearchByDescriptionAsync(string descriptionText,
        CancellationToken cancellationToken = default);
}

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}