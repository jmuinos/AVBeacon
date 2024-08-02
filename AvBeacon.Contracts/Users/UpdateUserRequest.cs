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
    ///     Gets or sets the first name.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name.
    /// </summary>
    public required string LastName { get; set; }
}