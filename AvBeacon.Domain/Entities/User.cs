namespace AvBeacon.Domain.Entities;

public class User
{
    public long Id { get; init; }
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string? Mail { get; set; }
}