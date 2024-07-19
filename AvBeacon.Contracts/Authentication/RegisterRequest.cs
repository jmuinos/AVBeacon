namespace AvBeacon.Contracts.Authentication;

/// <summary>
/// Represents the register request.
/// </summary>
public sealed class RegisterRequest
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Gets or sets the user type.
    /// </summary>
    public string UserType { get; set; }
}