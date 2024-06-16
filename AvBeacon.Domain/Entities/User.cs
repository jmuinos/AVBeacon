using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain._Core.Utility;
using AvBeacon.Domain.Services;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary> Representa la entidad Usuario </summary>
public abstract class User : Entity
{
    private string _passwordHash;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="User" />.</summary>
    /// <param name="firstName">El nombre del usuario.</param>
    /// <param name="lastName">El apellido del usuario.</param>
    /// <param name="email">El correo electrónico del usuario.</param>
    /// <param name="passwordHash">La contraseña del usuario.</param>
    protected User(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(Guid.NewGuid())
    {
        Ensure.NotEmpty(firstName, "The first name is required.", nameof(firstName));
        Ensure.NotEmpty(lastName, "The last name is required.", nameof(lastName));
        Ensure.NotEmpty(email, "The email is required.", nameof(email));
        Ensure.NotEmpty(passwordHash, "The password hash is required", nameof(passwordHash));

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _passwordHash = passwordHash;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    /// <summary>Obtiene el nombre completo del usuario.</summary>
    public string FullName => $"{FirstName} {LastName}";

    public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker) =>
        !string.IsNullOrWhiteSpace(password) && passwordHashChecker.HashesMatch(_passwordHash, password);

    public Result ChangePassword(string passwordHash)
    {
        if (passwordHash == _passwordHash)
            return Result.Failure(DomainErrors.User.CannotChangePassword);

        _passwordHash = passwordHash;
        return Result.Success();
    }

    public void ChangeName(FirstName firstName, LastName lastName)
    {
        Ensure.NotEmpty(firstName, "The first name is required.", nameof(firstName));
        Ensure.NotEmpty(lastName, "The last name is required.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }
}