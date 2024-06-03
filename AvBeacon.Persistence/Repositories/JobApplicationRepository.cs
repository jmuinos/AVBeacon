using AvBeacon.Domain._Core.Enumerables;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Persistence.Repositories;

public class JobApplicationRepository(ApplicationDbContext context)
    : GenericRepository<JobApplication>(context), IJobApplicationRepository
{
    public async Task<JobApplication?> GetAllByCandidateIdAsync<T>(Guid candidateId,
        CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(new object?[] { candidateId, cancellationToken }, cancellationToken);
    }

    public async Task<JobApplication?> GetByCandidateIdAndState<T>(Guid id, JobApplicationState jobApplicationState,
        CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
    }
}