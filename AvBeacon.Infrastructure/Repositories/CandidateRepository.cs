using AvBeacon.Domain.Candidates;

namespace AvBeacon.Infrastructure.Repositories;

public class CandidateRepository(ApplicationDbContext context)
    : GenericRepository<Candidate>(context), ICandidateRepository;