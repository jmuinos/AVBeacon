using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;
using AVBEACON.Persistence;

namespace AvBeacon.Persistence.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository;