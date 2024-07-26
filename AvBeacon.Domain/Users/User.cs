﻿using AvBeacon.Domain.Core.Abstractions;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Guards;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Result;
using AvBeacon.Domain.Users.DomainEvents;

namespace AvBeacon.Domain.Users
{
    /// <summary>Represents the user entity.</summary>
    public class User : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        private string _passwordHash;

        /// <summary>Initializes a new instance of the <see cref="User" /> class.</summary>
        /// <param name="firstName">The user first name.</param>
        /// <param name="lastName">The user last name.</param>
        /// <param name="email">The user email instance.</param>
        /// <param name="passwordHash">The user password hash.</param>
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

        /// <summary>Gets the user first name.</summary>
        public FirstName FirstName { get; private set; }

        /// <summary>Gets the user last name.</summary>
        public LastName LastName { get; private set; }

        /// <summary>Gets the user full name.</summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>Gets the user email.</summary>
        public Email Email { get; private set; }

        /// <inheritdoc />
        public DateTime CreatedOnUtc { get; init; }

        /// <inheritdoc />
        public DateTime? ModifiedOnUtc { get; set; }

        /// <inheritdoc />
        public DateTime? DeletedOnUtc { get; init; }

        /// <inheritdoc />
        public bool Deleted { get; init; }

        /// <summary>Creates a new user with the specified first name, last name, email and password hash.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns>The newly created user instance.</returns>
        public static User Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
        {
            var user = new User(firstName, lastName, email, passwordHash);

            user.AddDomainEvent(new UserPasswordChangedDomainEvent(user));

            return user;
        }

        /// <summary>Verifies that the provided password hash matches the password hash.</summary>
        /// <param name="password">The password to be checked against the user password hash.</param>
        /// <param name="passwordHashChecker">The password hash checker.</param>
        /// <returns>True if the password hashes match, otherwise false.</returns>
        public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker)
        {
            return !string.IsNullOrWhiteSpace(password) && passwordHashChecker.HashesMatch(_passwordHash, password);
        }

        /// <summary>Changes the users password.</summary>
        /// <param name="passwordHash">The password hash of the new password.</param>
        /// <returns>The success result or an error.</returns>
        public Result ChangePassword(string passwordHash)
        {
            if (passwordHash == _passwordHash) return Result.Failure(DomainErrors.User.CannotChangePassword);

            _passwordHash = passwordHash;

            AddDomainEvent(new UserPasswordChangedDomainEvent(this));

            return Result.Success();
        }

        /// <summary>Changes the users first and last name.</summary>
        /// <param name="firstName">The new first name.</param>
        /// <param name="lastName">The new last name.</param>
        public void ChangeName(FirstName firstName, LastName lastName)
        {
            Ensure.NotEmpty(firstName, "The first name is required.", nameof(firstName));
            Ensure.NotEmpty(lastName, "The last name is required.", nameof(lastName));

            FirstName = firstName;

            LastName = lastName;

            AddDomainEvent(new UserNameChangedDomainEvent(this));
        }
    }
}