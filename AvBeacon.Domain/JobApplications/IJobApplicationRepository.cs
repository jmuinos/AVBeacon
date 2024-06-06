using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.JobApplications;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
    Task<List<JobApplication>> GetByApplicantNameAsync(string nameText, CancellationToken cancellationToken = default);
}