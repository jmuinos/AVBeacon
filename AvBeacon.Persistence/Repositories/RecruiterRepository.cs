using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;
using AVBEACON.Persistence;

namespace AvBeacon.Persistence.Repositories;

public class RecruiterRepository(ApplicationDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository;