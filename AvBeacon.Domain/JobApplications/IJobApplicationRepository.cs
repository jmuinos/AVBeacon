using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.JobApplications;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication?> GetAllByCandidateIdAsync<T>(Guid candidateId, CancellationToken cancellationToken = default);

    Task<JobApplication?> GetByCandidateIdAndState<T>(Guid candidateId, JobApplicationState jobApplicationState, CancellationToken cancellationToken = default);
    
    Task<JobApplication?> GetAllByTitleAsync<T>(string titleText, CancellationToken cancellationToken = default);

}