using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain._Interfaces;

public abstract class User(Guid id, string email, string firstName, string lastName)
    : Entity(id)
{
    public string Email { get; private init; } = email;
    public string FirstName { get; private init; } = firstName;
    public string LastName { get; private init; } = lastName;
}