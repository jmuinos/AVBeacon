using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.JobApplications;

namespace AvBeacon.Domain.JobOffers;

public sealed class JobOffer(Guid id, Guid recruiterId, string title,
    string description, List<JobApplication>? jobApplications)
    : Entity(id)
{
    public Guid RecruiterId { get; private init; } = recruiterId;
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public List<JobApplication>? JobApplications { get; private set; } = jobApplications;
}