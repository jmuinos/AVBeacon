using AvBeacon.Domain.Recruiters;

namespace AvBeacon.Infrastructure.Repositories;

public class RecruiterRepository(ApplicationDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository
{
    // TODO
    public Task<Recruiter?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}