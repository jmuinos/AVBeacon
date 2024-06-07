namespace AvBeacon.Domain.Entities;

public sealed class Recruiter : User
{
    public Recruiter(string email, string firstName, string lastName, string passwordHash)
        : base(email, firstName, lastName, passwordHash) { }

    public List<JobOffer> JobOffers { get; init; } = [];
}