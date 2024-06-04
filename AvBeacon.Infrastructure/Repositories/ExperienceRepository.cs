using AvBeacon.Domain.Experiences;

namespace AvBeacon.Infrastructure.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
    public Task<Experience?> GetAllByTitle<T>(string titleText, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
    public Task<Experience?> GetAllByCandidateId<T>(Guid candidateId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
    public Task<Experience?> GetAllByDateRangeDaysPassed<T>(Guid candidateId, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }
}