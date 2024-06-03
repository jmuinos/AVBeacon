using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.JobApplications;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication?> GetAllByCandidateIdAsync<T>(Guid candidateId, CancellationToken cancellationToken);

    Task<JobApplication?> GetByCandidateIdAndState<T>(Guid id, JobApplicationStateEnum jobApplicationStateEnum,
                                                      CancellationToken cancellationToken);
}