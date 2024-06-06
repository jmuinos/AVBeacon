using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Recruiters;

namespace AvBeacon.Domain.JobOffers;

public sealed class JobOffer(Guid id, Guid recruiterId, string title, string description)
    : Entity(id)
{
    public Guid RecruiterId { get; private set; } = recruiterId;
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;

    // Propiedad de navegación a Recruiter
    public Recruiter Recruiter { get; init; } = null!;
}