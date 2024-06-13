namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud de actualización de usuario. </summary>
public sealed record UpdateUserRequest
{
    public Guid UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}