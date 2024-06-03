using AvBeacon.Domain.Skills;

namespace AvBeacon.Infrastructure.Repositories;

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository;