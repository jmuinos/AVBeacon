using AvBeacon.Domain.Educations;

namespace AvBeacon.Infrastructure.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository;