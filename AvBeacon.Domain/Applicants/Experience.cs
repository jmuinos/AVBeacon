using AvBeacon.Domain.Common;
using AvBeacon.Domain.Core.Primitives;

namespace AvBeacon.Domain.Applicants;

public sealed class Experience : Entity
{
    private Experience(Guid applicantId, Title title, Description description, DateTime? start, DateTime? end)
        : base(Guid.NewGuid())
    {
        ApplicantId = applicantId;
        Title       = title;
        Description = description;
        Start       = start;
        End         = end;
    }

    public static Experience Create(Guid applicantId, Title title, Description description, DateTime? start,
        DateTime? end)
    {
        return new Experience(applicantId, title, description, start, end);
    }

    #region Propiedades

    public Title Title { get; set; }
    public Description Description { get; set; }
    public DateTime? Start { get; init; }
    public DateTime? End { get; set; }

    #endregion

    #region Propiedades de navegación

    public Guid ApplicantId { get; init; }
    public Applicant Applicant { get; init; } = null!;

    #endregion
}