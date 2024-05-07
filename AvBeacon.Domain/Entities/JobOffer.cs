namespace AvBeacon.Domain.Entities;

public class JobOffer
{
    public long Id { get; init; }
    public long RecruiterId { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}