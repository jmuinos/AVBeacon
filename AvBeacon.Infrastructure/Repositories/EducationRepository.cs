using AvBeacon.Domain.Core.Interfaces.Repositories;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Infrastructure.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository;