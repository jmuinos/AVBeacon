using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Domain._Core.Factories;

public class ApplicantFactory : UserFactoryBase<Applicant>
{
    public override Applicant Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Applicant(firstName, lastName, email, passwordHash);
    }
}