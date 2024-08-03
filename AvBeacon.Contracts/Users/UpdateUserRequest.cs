namespace AvBeacon.Contracts.Users;

/// <summary>
///     Represents the update user request.
/// </summary>
public sealed class UpdateUserRequest
{
    /// <summary>
    ///     Gets or sets the user identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the firstname.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the lastname.
    /// </summary>
    public required string LastName { get; set; }
}