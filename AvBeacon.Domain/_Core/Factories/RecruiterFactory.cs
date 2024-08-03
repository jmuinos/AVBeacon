using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Recruiters;
using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Domain._Core.Factories;

public class RecruiterFactory : UserFactoryBase<Applicant>
{
    public override Recruiter Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Recruiter(firstName, lastName, email, passwordHash);
    }
}