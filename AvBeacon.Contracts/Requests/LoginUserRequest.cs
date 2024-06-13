namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud de inicio de sesión. </summary>
public sealed record LoginUserRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}