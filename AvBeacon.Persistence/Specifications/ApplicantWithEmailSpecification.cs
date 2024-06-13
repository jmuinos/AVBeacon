using System.Linq.Expressions;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Persistence.Specifications;

/// <summary> Represents the specification for determining the applicant with email. </summary>
internal sealed class ApplicantWithEmailSpecification : Specification<Applicant>
{
    private readonly Email _email;

    /// <summary> Initializes a new instance of the <see cref="ApplicantWithEmailSpecification" /> class. </summary>
    /// <param name="email"> The email. </param>
    internal ApplicantWithEmailSpecification(Email email) { _email = email; }

    /// <inheritdoc />
    internal override Expression<Func<Applicant, bool>> ToExpression()
    {
        return applicant => applicant.Email.Value == _email;
    }
}