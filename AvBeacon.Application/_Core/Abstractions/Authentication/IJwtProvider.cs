using AvBeacon.Domain.Entities;

namespace AvBeacon.Application._Core.Abstractions.Authentication;

/// <summary> Representa la interfaz del proveedor de JWT</summary>
public interface IJwtProvider
{
    /// <summary> Crea el JWT para el usuario. </summary>
    /// <param name="user"> El usuario </param>
    /// <returns> El JWT para el usuario. </returns>
    string Create(User user);
}