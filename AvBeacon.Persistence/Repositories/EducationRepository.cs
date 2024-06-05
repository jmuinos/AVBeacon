using AvBeacon.Domain.Educations;

namespace AvBeacon.Persistence.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository
{
    // TODO
    public Task<Education?> GetAllBySimilarTitle<T>(string title, CancellationToken cancellationToken = default) { throw new NotImplementedException(); }

    public Task<Education?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}