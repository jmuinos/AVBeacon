using AvBeacon.Domain.Users.Recruiters;

namespace AvBeacon.Persistence.Repositories;

public class RecruiterRepository(ApplicationDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository
{
    // TODO
    public Task<Recruiter?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Recruiter?> GetAllByEmailAsync<T>(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}