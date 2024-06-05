using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Users;

namespace AvBeacon.Persistence.Repositories;

public class ApplicantRepository(ApplicationDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    // TODO
    public Task<Applicant?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Applicant?> GetAllByEmailAsync<T>(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}