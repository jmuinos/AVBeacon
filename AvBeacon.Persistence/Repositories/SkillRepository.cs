using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;

namespace AvBeacon.Persistence.Repositories;

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository;