using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Persistence.Repositories;

internal sealed class SkillRepository(IDbContext context)
    : GenericRepository<Skill>(context), ISkillRepository;