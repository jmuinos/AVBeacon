using AvBeacon.Domain.Core.Interfaces.Repositories;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Infrastructure.Repositories;

public class CandidateRepository(ApplicationDbContext context)
    : GenericRepository<Candidate>(context), ICandidateRepository;