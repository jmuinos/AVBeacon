using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using Microsoft.AspNetCore.Identity;

namespace AvBeacon.Domain.Entities;

public abstract class User : Entity
{
    private string _passwordHash;

    protected User(string email, string firstName, string lastName, string passwordHash)
        : base(Guid.NewGuid())
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        _passwordHash = passwordHash;
    }


    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
    {
        _passwordHash = passwordHasher.HashPassword(this, password);
    }

    public Result ChangePassword(string passwordHash)
    {
        if (passwordHash == _passwordHash) return Result.Failure(DomainErrors.User.CannotChangePassword);
        _passwordHash = passwordHash;

        return Result.Success();
    }

    public bool VerifyPassword(string password, IPasswordHasher<User> passwordHasher)
    {
        return passwordHasher.VerifyHashedPassword(this, _passwordHash, password) == PasswordVerificationResult.Success;
    }

    public void ChangeName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}