using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Infrastructure.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository
{
    // TODO
    public Task<Education?> GetAllBySimilarTitle<T>(Title title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Education?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}