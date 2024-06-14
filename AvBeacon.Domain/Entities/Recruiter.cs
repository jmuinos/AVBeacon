using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Recruiter : User
{
    public Recruiter(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash) { }

// En Recruiter
    public ICollection<JobOffer> JobOffers { get; private set; } = new List<JobOffer>();

    public static Recruiter Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Recruiter(firstName, lastName, email, passwordHash);
    }
}