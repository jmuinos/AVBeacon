using AvBeacon.Domain.Educations;

namespace AvBeacon.Infrastructure.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository
{
    public Task<Education?> GetAllByTitle<T>(string titleText, CancellationToken cancellationToken = default)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Task<Education?> GetAllByCandidateId<T>(Guid candidateId, CancellationToken cancellationToken = default)
    {
        // TODO
        throw new NotImplementedException();
    }
}