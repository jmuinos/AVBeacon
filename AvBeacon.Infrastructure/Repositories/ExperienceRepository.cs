using AvBeacon.Domain.Experiences;

namespace AvBeacon.Infrastructure.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository;