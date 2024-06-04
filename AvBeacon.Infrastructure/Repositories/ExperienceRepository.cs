using AvBeacon.Domain.Experiences;

namespace AvBeacon.Infrastructure.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
    public Task<Experience?> GetAllByTitle<T>(string titleText, CancellationToken cancellationToken = default)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Task<Experience?> GetAllByCandidateId<T>(Guid candidateId, CancellationToken cancellationToken = default)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Task<Experience?> GetAllByMinExperienceDays<T>(int minExperienceDays,
        CancellationToken cancellationToken = default)
    {
        // TODO
        throw new NotImplementedException();
    }
}

