using AvBeacon.Domain.JobOffers;

namespace AvBeacon.Domain.Users.Recruiters;

public sealed class Recruiter(Guid id, string email, string firstName, string lastName, List<JobOffer>? jobOffers)
    : User(id, email, firstName, lastName)
{
    public List<JobOffer>? JobOffers { get; private set; } = jobOffers;
}