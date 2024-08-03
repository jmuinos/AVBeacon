using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Domain._Core.Factories;

public abstract class UserFactoryBase<TUser> : IUserFactory where TUser : User
{
    public abstract User Create(FirstName firstName, LastName lastName, Email email, string passwordHash);
}