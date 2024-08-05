using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Guards;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Domain.Users.Shared;

/// <summary>
///     Represents the user entity.
/// </summary>
public class User : Entity, IAuditableEntity, ISoftDeletableEntity
{
    private string _passwordHash;

    /// <summary>
    ///     Initializes a new instance of the <see cref="User" /> class.
    /// </summary>
    /// <param name="firstName"> The user firstname. </param>
    /// <param name="lastName"> The user lastname. </param>
    /// <param name="email"> The user email instance. </param>
    /// <param name="passwordHash"> The user password hash. </param>
    /// <param name="userType"> The user type. </param>
    protected User(FirstName firstName, LastName lastName, Email email, string passwordHash, UserType userType)
        : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(firstName, "The firstname is required.", nameof(firstName));
        Ensure.NotEmpty(lastName, "The lastname is required.", nameof(lastName));
        Ensure.NotEmpty(email, "The email is required.", nameof(email));
        Ensure.NotEmpty(passwordHash, "The password hash is required", nameof(passwordHash));

        FirstName     = firstName;
        LastName      = lastName;
        Email         = email;
        _passwordHash = passwordHash;
        UserType      = userType;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public UserType UserType { get; private set; }

    /// <summary>
    ///     Gets the user full name.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; init; }

    /// <inheritdoc />
    public bool Deleted { get; init; }

    public static User Create(FirstName firstName, LastName lastName, Email email, string passwordHash, UserType userType)
    {
        var user = new User(firstName, lastName, email, passwordHash, userType);

        return user;
    }
    
    /// <summary>
    ///     Verifies that the provided password hash matches the password hash.
    /// </summary>
    /// <param name="password"> The password to be checked against the user password hash. </param>
    /// <param name="passwordHashChecker"> The password hash checker. </param>
    /// <returns> True if the password hashes match, otherwise false. </returns>
    public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker)
    {
        return !string.IsNullOrWhiteSpace(password) && passwordHashChecker.HashesMatch(_passwordHash, password);
    }

    /// <summary>
    ///     Changes the users password.
    /// </summary>
    /// <param name="passwordHash"> The password hash of the new password. </param>
    /// <returns> The success result or an error. </returns>
    public Result ChangePassword(string passwordHash)
    {
        if (passwordHash == _passwordHash)
            return Result.Failure(DomainErrors.Users.CannotChangePassword);

        _passwordHash = passwordHash;

        return Result.Success();
    }

    /// <summary>
    ///     Changes the users first and lastname.
    /// </summary>
    /// <param name="firstName"> The new firstname. </param>
    /// <param name="lastName"> The new lastname. </param>
    public void ChangeName(FirstName firstName, LastName lastName)
    {
        Ensure.NotEmpty(firstName, "The firstname is required.", nameof(firstName));
        Ensure.NotEmpty(lastName, "The lastname is required.", nameof(lastName));

        FirstName = firstName;
        LastName  = lastName;
    }
}