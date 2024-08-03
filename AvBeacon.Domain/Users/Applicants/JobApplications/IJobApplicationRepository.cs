using AvBeacon.Domain._Core.Abstractions;

namespace AvBeacon.Domain.Users.Applicants.JobApplications;

public interface IJobApplicationRepository : IBaseRepository<JobApplication>
{
    Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
    Task<List<JobApplication>> GetByJobOfferIdAsync(Guid jobOfferId, CancellationToken cancellationToken = default);
}