using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Persistence.Repositories;

public class CandidateRepository(ApplicationDbContext context)
    : GenericRepository<Candidate>(context), ICandidateRepository;