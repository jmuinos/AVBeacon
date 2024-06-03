using AvBeacon.Domain.Core.Interfaces.Repositories;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Infrastructure.Repositories;

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository;