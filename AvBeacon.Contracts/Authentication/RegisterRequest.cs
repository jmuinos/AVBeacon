namespace AvBeacon.Contracts.Authentication;

/// <summary>
///     Represents the register request.
/// </summary>
public sealed class RegisterRequest
{
    /// <summary>
    ///     Gets or sets the firstname.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the lastname.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    ///     Gets or sets the email.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    ///     Gets or sets the password.
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    ///     Gets or sets the user type.
    /// </summary>
    public required string UserType { get; set; }
}