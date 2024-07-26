using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Persistence.Repositories
{
    internal sealed class SkillRepository(IDbContext context)
        : GenericRepository<Skill>(context), ISkillRepository;
}