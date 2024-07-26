using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Recruiters
{
    public sealed class Recruiter : User
    {
        private Recruiter(FirstName firstName, LastName lastName, Email email, string passwordHash)
            : base(firstName, lastName, email, passwordHash) { }

        public ICollection<JobOffer> JobOffers { get; private set; } = new List<JobOffer>();

        public new static Recruiter Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
        {
            return new Recruiter(firstName, lastName, email, passwordHash);
        }
    }
}