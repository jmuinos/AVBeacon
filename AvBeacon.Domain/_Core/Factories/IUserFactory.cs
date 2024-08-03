using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Domain._Core.Factories;

public interface IUserFactory
{
    User Create(FirstName firstName, LastName lastName, Email email, string passwordHash);
}