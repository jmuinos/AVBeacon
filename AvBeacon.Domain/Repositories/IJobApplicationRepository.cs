using AvBeacon.Domain._Core.Enumerables;
using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication?> GetAllByCandidateIdAsync<T>(Guid candidateId, CancellationToken cancellationToken);

    Task<JobApplication?> GetByCandidateIdAndState<T>(Guid id, JobApplicationState jobApplicationState,
        CancellationToken cancellationToken);
}