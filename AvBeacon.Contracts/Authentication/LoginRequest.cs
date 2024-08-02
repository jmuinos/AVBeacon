namespace AvBeacon.Contracts.Authentication;

/// <summary>
///     Represents the login request.
/// </summary>
public sealed class LoginRequest
{
    /// <summary>
    ///     Gets or sets the email.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    ///     Gets or sets the password
    /// </summary>
    public required string Password { get; set; }
}