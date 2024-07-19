namespace AvBeacon.Contracts.Users;

/// <summary> Representa la respuesta del usuario. </summary>
public class UserResponse
{
    public required Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}