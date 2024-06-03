using AvBeacon.Domain.Core.Interfaces.Repositories;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Infrastructure.Repositories;

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository;