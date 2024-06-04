using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.JobOffers;

/// <summary>Representa una oferta de trabajo creada por un usuario reclutador.</summary>
public sealed class JobOffer(
    Guid id,
    Guid recruiterId,
    Title title,
    Description description,
    List<JobApplication>? jobApplications)
    : Entity(id)
{
    public Guid RecruiterId { get; private init; } = recruiterId;
    public Title Title { get; private set; } = title;
    public Description Description { get; private set; } = description;
    public List<JobApplication>? JobApplications { get; private set; } = jobApplications;
}