using AvBeacon.Domain.JobApplications;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

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