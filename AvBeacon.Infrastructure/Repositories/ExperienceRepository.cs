using AvBeacon.Domain.Core.Interfaces.Repositories;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Infrastructure.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository;