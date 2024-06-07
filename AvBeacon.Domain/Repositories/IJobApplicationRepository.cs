using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Repositories;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);

    Task<List<JobApplication>> GetByApplicantIdAndStateAsync(Guid applicantId, JobApplicationState state,
        CancellationToken cancellationToken = default);

    // Task<List<JobApplication>> GetByRecruiterIdAsync(Guid recruiterId, CancellationToken cancellationToken = default);
}