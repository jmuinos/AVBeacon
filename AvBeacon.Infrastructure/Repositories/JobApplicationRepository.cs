using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Infrastructure.Repositories;

public class JobApplicationRepository(ApplicationDbContext context)
    : GenericRepository<JobApplication>(context), IJobApplicationRepository
{
    public async Task<JobApplication?> GetAllByApplicantIdAsync<T>(Guid applicantId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object?[] { applicantId, cancellationToken }, cancellationToken);
    }

    public async Task<JobApplication?> GetAllByApplicantIdAndStateAsync<T>(Guid id,
        JobApplicationState jobApplicationState, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
    }

    public Task<JobApplication?> GetAllBySimilarTitleAsync<T>(Title title,
        CancellationToken cancellationToken = default)
    {
        // TODO
        throw new NotImplementedException();
    }
}