namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud de cambio de contraseña. </summary>
public sealed record ChangePasswordRequest
{
    public required Guid UserId { get; set; }
    public string? Password { get; set; }
}