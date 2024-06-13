using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Repositories;

public interface IRecruiterRepository
{
    Task<Maybe<Recruiter>> GetByIdAsync(Guid id);
    void Insert(Recruiter recruiter);
    void Update(Recruiter recruiter);
    void Remove(Recruiter recruiter);
    Task<Maybe<Recruiter>> GetByEmailAsync(Email email);
    Task<List<Recruiter>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUniqueAsync(Email email);
}