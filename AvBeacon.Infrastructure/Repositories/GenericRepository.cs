using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T>
    where T : class
{
    protected readonly ApplicationDbContext Context = context;
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity) { DbSet.Update(entity); }

    public void Delete(T entity) { DbSet.Remove(entity); }
}

public class ApplicantRepository(ApplicationDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    public async Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(a => EF.Functions.Like(a.FirstName, $"%{nameText}%") ||
                                EF.Functions.Like(a.LastName, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }

    public async Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }
}

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository
{
    public async Task<List<Education>> SearchByDescriptionAsync(string descriptionText,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(e => EF.Functions.Like(e.Description, $"%{descriptionText}%"))
                    .ToListAsync(cancellationToken);
    }
}

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
    public async Task<List<Experience>> SearchByTitleAsync(string titleText,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(e => EF.Functions.Like(e.Title, $"%{titleText}%"))
                    .ToListAsync(cancellationToken);
    }
}

public class JobApplicationRepository(ApplicationDbContext context)
    : GenericRepository<JobApplication>(context), IJobApplicationRepository
{
    public async Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(ja => ja.ApplicantId == applicantId)
                    .ToListAsync(cancellationToken);
    }

    public async Task<List<JobApplication>> GetByApplicantNameAsync(string nameText,
        CancellationToken cancellationToken = default)
    {
        return await Context.JobApplications
                            .Include(ja => ja.Applicant)
                            .Where(ja => EF.Functions.Like(ja.Applicant.FirstName, $"%{nameText}%") ||
                                         EF.Functions.Like(ja.Applicant.LastName, $"%{nameText}%"))
                            .ToListAsync(cancellationToken);
    }
}

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository
{
    public async Task<List<JobOffer>> SearchByTitleAsync(string titleText,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(jo => EF.Functions.Like(jo.Title, $"%{titleText}%"))
                    .ToListAsync(cancellationToken);
    }
}

public class RecruiterRepository(ApplicationDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository
{
    public async Task<Recruiter?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(r => r.Email == email, cancellationToken);
    }

    public async Task<List<Recruiter>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(r => EF.Functions.Like(r.FirstName, $"%{nameText}%") ||
                                EF.Functions.Like(r.LastName, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }
}

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository
{
    public async Task<List<Skill>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(s => EF.Functions.Like(s.Name, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }
}