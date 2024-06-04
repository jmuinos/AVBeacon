using AvBeacon.Domain.JobOffers;

namespace AvBeacon.Infrastructure.Repositories;

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository
{
    // TODO

}