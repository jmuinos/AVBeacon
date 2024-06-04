using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Candidates;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
    Task<Candidate?> GetByFirstNameAndOrLastNameAsync<T>(string nameText, CancellationToken cancellationToken = default);
    
}