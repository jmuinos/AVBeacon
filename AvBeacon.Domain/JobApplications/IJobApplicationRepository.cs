using AvBeacon.Domain._Core;

namespace AvBeacon.Domain.JobApplications;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication?> GetAllByApplicantIdAsync<T>(Guid applicantId, CancellationToken cancellationToken = default);

    Task<JobApplication?> GetAllByApplicantIdAndStateAsync<T>(Guid applicantId, JobApplicationState jobApplicationState,
        CancellationToken cancellationToken = default);

    Task<JobApplication?> GetAllBySimilarTitleAsync<T>(string title, CancellationToken cancellationToken = default);
}