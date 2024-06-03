using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Recruiters;

/// <summary>Representa un usuario de tipo reclutador.</summary>
public sealed class Recruiter(Guid id, Email email, FirstName firstName, LastName lastName, List<JobOffer>? jobOffers)
    : User(id, email, firstName, lastName)
{
    public List<JobOffer>? JobOffers { get; private set; } = jobOffers;
}