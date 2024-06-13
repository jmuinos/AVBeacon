using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Repositories;

public interface IApplicantRepository : IBaseRepository<Applicant>
{
    Task<List<Skill>> GetSkillsByApplicantId(Guid applicantId);
    Task<Maybe<Applicant>> GetByEmailAsync(Email email);
    Task<List<Applicant>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUniqueAsync(Email email);
}