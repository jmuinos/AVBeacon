using AvBeacon.Domain.Candidates;

namespace AvBeacon.Infrastructure.Repositories;

public class CandidateRepository(ApplicationDbContext context)
    : GenericRepository<Candidate>(context), ICandidateRepository
{
    public Task<Candidate?> GetByFirstNameAndOrLastNameAsync<T>(string nameText, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
}