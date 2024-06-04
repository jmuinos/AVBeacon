using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.JobApplications;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication?> GetAllByApplicantIdAsync<T>(Guid applicantId, CancellationToken cancellationToken = default);

    Task<JobApplication?> GetAllByApplicantIdAndStateAsync<T>(Guid applicantId, JobApplicationState jobApplicationState,
        CancellationToken cancellationToken = default);

    Task<JobApplication?> GetAllBySimilarTitleAsync<T>(Title title, CancellationToken cancellationToken = default);
}