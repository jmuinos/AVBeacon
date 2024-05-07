using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces.Repositories;
using AVBEACON.Persistence;

namespace AvBeacon.Persistence.Repositories;

public class JobApplicationRepository(ApplicationDbContext context)
    : GenericRepository<JobApplication>(context), IJobApplicationRepository;