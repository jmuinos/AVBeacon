using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Infrastructure.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
    // TODO
    public Task<Experience?> GetAllBySimilarTitle<T>(Title title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Experience?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Experience?> GetAllByMinExperienceDays<T>(int minExperienceDays,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}