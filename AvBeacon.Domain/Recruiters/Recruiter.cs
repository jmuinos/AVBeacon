using AvBeacon.Domain._Interfaces;
using AvBeacon.Domain.JobOffers;

namespace AvBeacon.Domain.Recruiters;

public sealed class Recruiter(Guid id, string email, string firstName, string lastName)
    : User(id, email, firstName, lastName)
{
    public List<JobOffer> JobOffers { get; } = new();

    public void AddJobOffer(JobOffer jobOffer) { JobOffers.Add(jobOffer); }

    public void RemoveJobOffer(Guid jobOfferId) { JobOffers.RemoveAll(jo => jo.Id == jobOfferId); }
}