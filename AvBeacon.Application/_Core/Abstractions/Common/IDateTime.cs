namespace AvBeacon.Application._Core.Abstractions.Common;

/// <remarks> Se usa principalmente para configurar y controlar la fecha de expiración de los token jwt </remarks>

public interface IDateTime
{
    DateTime UtcNow { get; }
}