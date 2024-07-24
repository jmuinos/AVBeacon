using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.Users.DomainEvents;

/// <summary>Represents the event that is raised when a user is created.</summary>
public sealed class UserCreatedDomainEvent : IDomainEvent
{
    /// <summary>Initializes a new instance of the <see cref="UserCreatedDomainEvent" /> class.</summary>
    /// <param name="user">The user.</param>
    internal UserCreatedDomainEvent(User user) { User = user; }

    /// <summary>Gets the user.</summary>
    public User User { get; }
}