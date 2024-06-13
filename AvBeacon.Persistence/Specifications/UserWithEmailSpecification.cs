using System.Linq.Expressions;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Persistence.Specifications;

/// <summary> Represents the specification for determining the user with email. </summary>
internal sealed class UserWithEmailSpecification : Specification<User>
{
    private readonly Email _email;

    /// <summary> Initializes a new instance of the <see cref="UserWithEmailSpecification" /> class. </summary>
    /// <param name="email"> The email. </param>
    internal UserWithEmailSpecification(Email email) { _email = email; }

    /// <inheritdoc />
    internal override Expression<Func<User, bool>> ToExpression() { return user => user.Email.Value == _email; }
}