using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Notifications;

/// <summary>
///     Represents the notification repository.
/// </summary>
public interface INotificationRepository
{
    /// <summary>
    ///     Gets the notifications along with their respective job offers and users that are waiting to be sent.
    /// </summary>
    /// <param name="batchSize"> The batch size. </param>
    /// <param name="utcNow"> The current date and time in UTC format. </param>
    /// <param name="allowedNotificationTimeDiscrepancyInMinutes">
    ///     The allowed discrepancy between the current time and the time the notification is supposed to be sent.
    /// </param>
    /// <returns> The notifications along with their respective job offers and users that are waiting to be sent. </returns>
    Task<(Notification notification, JobOffer jobOffer, User user)[]>
        GetNotificationsToBeSentIncludingUserAndJobOffer(
            int batchSize,
            DateTime utcNow,
            int allowedNotificationTimeDiscrepancyInMinutes);

    /// <summary>
    ///     Inserts the specified notifications to the database.
    /// </summary>
    /// <param name="notifications"> The notifications to be inserted into the database. </param>
    void InsertRange(IReadOnlyCollection<Notification> notifications);

    /// <summary>
    ///     Updates the specified notification in the database.
    /// </summary>
    /// <param name="notification"> The notification to be updated. </param>
    void Update(Notification notification);

    /// <summary>
    ///     Removes all the notifications for the job offer.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <param name="utcNow"> The current date and time in UTC format. </param>
    /// <returns> The completed task. </returns>
    Task RemoveNotificationsForJobOfferAsync(JobOffer jobOffer, DateTime utcNow);
}