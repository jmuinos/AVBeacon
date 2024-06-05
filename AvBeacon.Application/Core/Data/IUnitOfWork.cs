namespace AvBeacon.Application.Core.Data
{
    /// <summary>
    /// Represents the unit of work interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all of the pending changes in the unit of work.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of entities that have been saved.</returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
