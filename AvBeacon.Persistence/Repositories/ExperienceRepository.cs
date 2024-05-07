using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;
using AVBEACON.Persistence;

namespace AvBeacon.Persistence.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository;