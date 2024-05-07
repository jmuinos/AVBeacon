namespace AvBeacon.Domain.Entities;

public class Experience
{
    public long Id { get; init; }
    public required string Description { get; set; }
    public string? RecruiterName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}