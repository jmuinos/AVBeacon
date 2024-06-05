using AvBeacon.Domain.Users.Experiences;

namespace AvBeacon.Persistence.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
    // TODO
    public Task<Experience?> GetAllBySimilarTitle<T>(string title, CancellationToken cancellationToken = default)
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