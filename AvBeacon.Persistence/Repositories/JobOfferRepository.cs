using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Persistence.Repositories;

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository;