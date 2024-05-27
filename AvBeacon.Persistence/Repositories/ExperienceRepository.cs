using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;

namespace AvBeacon.Persistence.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository;