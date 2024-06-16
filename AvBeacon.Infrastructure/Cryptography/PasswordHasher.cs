using System.Security.Cryptography;
using AvBeacon.Application._Core.Abstractions.Cryptography;
using AvBeacon.Domain.Services;
using AvBeacon.Domain.ValueObjects;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AvBeacon.Infrastructure.Cryptography;

/// <summary> Representa el generador de contraseñas, utilizado para generar contraseñas y verificar contraseñas generadas. </summary>
internal sealed class PasswordHasher : IPasswordHasher, IPasswordHashChecker, IDisposable
{
    private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;
    private const int IterationCount = 10000;
    private const int NumberOfBytesRequested = 256 / 8;
    private const int SaltSize = 128 / 8;
    private readonly RandomNumberGenerator _rng;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="PasswordHasher" /></summary>
    public PasswordHasher() { _rng = RandomNumberGenerator.Create(); }

    /// <inheritdoc />
    public void Dispose() { _rng.Dispose(); }

    /// <inheritdoc />
    public bool HashesMatch(string passwordHash, string providedPassword)
    {
        if (passwordHash is null)
            throw new ArgumentNullException(nameof(passwordHash));

        if (providedPassword is null)
            throw new ArgumentNullException(nameof(providedPassword));

        var decodedHashedPassword = Convert.FromBase64String(passwordHash);

        if (decodedHashedPassword.Length == 0)
            return false;

        var verified = VerifyPasswordHashInternal(decodedHashedPassword, providedPassword);

        return verified;
    }

    /// <inheritdoc />
    public string HashPassword(Password password)
    {
        if (password is null)
            throw new ArgumentNullException(nameof(password));

        var hashedPassword = Convert.ToBase64String(HashPasswordInternal(password));

        return hashedPassword;
    }

    /// <summary> Devuelve los bytes del hash para la contraseña especificada. </summary>
    /// <param name="password"> La contraseña a ser hashed. </param>
    /// <returns> Los bytes del hash para la contraseña especificada.</returns>
    private byte[] HashPasswordInternal(string password)
    {
        var salt = GetRandomSalt();

        var subKey = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, NumberOfBytesRequested);

        var outputBytes = new byte[salt.Length + subKey.Length];

        Buffer.BlockCopy(salt, 0, outputBytes, 0, salt.Length);

        Buffer.BlockCopy(subKey, 0, outputBytes, salt.Length, subKey.Length);

        return outputBytes;
    }

    /// <summary> Devuelve una sal generada aleatoriamente.</summary>
    /// <returns> La sal generada aleatoriamente. </returns>
    private byte[] GetRandomSalt()
    {
        var salt = new byte[SaltSize];
        _rng.GetBytes(salt);
        return salt;
    }

    /// <summary> Verifica los bytes de la contraseña hashed con la contraseña especificada. </summary>
    /// <param name="hashedPassword"> Los bytes de la contraseña hashed. </param>
    /// <param name="password"> La contraseña a verificar. </param>
    /// <returns> Verdadero si los hashes coinciden, de lo contrario falso. </returns>
    private static bool VerifyPasswordHashInternal(byte[] hashedPassword, string password)
    {
        try
        {
            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPassword, 0, salt, 0, salt.Length);

            var subKeyLength = hashedPassword.Length - salt.Length;
            if (subKeyLength < SaltSize)
                return false;

            var expectedSubKey = new byte[subKeyLength];
            Buffer.BlockCopy(hashedPassword, salt.Length, expectedSubKey, 0, expectedSubKey.Length);

            var actualSubKey = KeyDerivation.Pbkdf2(password, salt, Prf, IterationCount, subKeyLength);
            return ByteArraysEqual(actualSubKey, expectedSubKey);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>Compara dos matrices de bytes para determinar si son iguales.</summary>
    /// <param name="a">La primera matriz de bytes.</param>
    /// <param name="b"> La segunda matriz de bytes.</param>
    /// <returns>True si las matrices son iguales, de lo contrario falso.</returns>
    private static bool ByteArraysEqual(byte[]? a, byte[]? b)
    {
        if (a == null && b == null)
            return true;
        if (a == null || b == null || a.Length != b.Length)
            return false;

        var areSame = true;
        for (var i = 0; i < a.Length; i++)
            areSame &= a[i] == b[i];

        return areSame;
    }
}