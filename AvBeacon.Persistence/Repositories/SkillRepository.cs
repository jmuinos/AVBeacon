using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;
using AVBEACON.Persistence;

namespace AvBeacon.Persistence.Repositories;

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository;