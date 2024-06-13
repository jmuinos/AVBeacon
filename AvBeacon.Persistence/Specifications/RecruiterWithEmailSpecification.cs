using System.Linq.Expressions;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Persistence.Specifications;

/// <summary> Represents the specification for determining the applicant with email. </summary>
internal sealed class RecruiterWithEmailSpecification : Specification<Recruiter>
{
    private readonly Email _email;

    /// <summary> Initializes a new instance of the <see cref="RecruiterWithEmailSpecification" /> class. </summary>
    /// <param name="email"> The email. </param>
    internal RecruiterWithEmailSpecification(Email email) { _email = email; }

    /// <inheritdoc />
    internal override Expression<Func<Recruiter, bool>> ToExpression()
    {
        return recruiter => recruiter.Email.Value == _email;
    }
}