using AvBeacon.Domain.Core.Enumerables;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Core.Interfaces.Repositories;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication?> GetAllByCandidateIdAsync<T>(Guid candidateId, CancellationToken cancellationToken);

    Task<JobApplication?> GetByCandidateIdAndState<T>(Guid id, JobApplicationState jobApplicationState,
        CancellationToken cancellationToken);
}