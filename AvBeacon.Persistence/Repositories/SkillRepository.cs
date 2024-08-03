using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Users.Applicants.Skills;

namespace AvBeacon.Persistence.Repositories;

internal sealed class SkillRepository(IDbContext context)
    : BaseRepository<Skill>(context), ISkillRepository;