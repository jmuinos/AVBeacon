using AvBeacon.Domain.Recruiters;

namespace AvBeacon.Infrastructure.Repositories;

public class RecruiterRepository(ApplicationDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository
{
    // TODO

}