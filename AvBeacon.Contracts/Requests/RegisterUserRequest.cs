namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud de registro. </summary>
public sealed record RegisterUserRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string UserType { get; init; }
}