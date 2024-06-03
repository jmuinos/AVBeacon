namespace AvBeacon.Application.DTOs;

public class CandidateDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Mail { get; set; }
}