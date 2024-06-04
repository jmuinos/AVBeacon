using AvBeacon.Domain.Applicants;

namespace AvBeacon.Infrastructure.Repositories;

public class ApplicantRepository(ApplicationDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    // TODO
    public Task<Applicant?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}