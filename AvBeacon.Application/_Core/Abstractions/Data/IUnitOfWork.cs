using Microsoft.EntityFrameworkCore.Storage;

namespace AvBeacon.Application._Core.Abstractions.Data;

/// <summary> Representa la interfaz de unidad de trabajo. </summary>
public interface IUnitOfWork
{
    /// <summary> Guarda todos los cambios pendientes en la unidad de trabajo. </summary>
    /// <param name="cancellationToken"> El token de cancelación. </param>
    /// <returns> El número de entidades que han sido guardadas. </returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary> Inicia una transacción en la unidad de trabajo actual. </summary>
    /// <param name="cancellationToken"> El token de cancelación. </param>
    /// <returns> La nueva transacción del contexto de base de datos. </returns>
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}