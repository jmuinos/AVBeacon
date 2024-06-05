using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Users.Recruiters;

namespace AvBeacon.Domain.Users;

public abstract class User(Guid id, string email, string firstName, string lastName)
    : Entity(id)
{
    public string Email { get; private init; } = email;
    public string FirstName { get; private init; } = firstName;
    public string LastName { get; private init; } = lastName;
}