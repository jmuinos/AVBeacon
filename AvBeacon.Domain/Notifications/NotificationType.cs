using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Maybe;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Notifications;

/// <summary>
///     Represents the notification types enumeration.
/// </summary>
public abstract class NotificationType : Enumeration<NotificationType>
{
    /// <summary>
    ///     The day before notification type.
    /// </summary>
    public static readonly NotificationType DayBefore = new DayBeforeNotificationType();

    /// <summary>
    ///     Initializes a new instance of the <see cref="NotificationType" /> class.
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <param name="name"> The name. </param>
    private NotificationType(int value, string name)
        : base(value, name) { }

    /// <summary>
    ///     Attempts to create a notification for the specified job offer and user identifier, based on the current date and time.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <param name="userId"> The user identifier. </param>
    /// <param name="utcNow"> The current date and time. </param>
    /// <returns> The maybe instance that may contain the notification. </returns>
    public abstract Maybe<Notification> TryCreateNotification(JobOffer jobOffer, Guid userId, DateTime utcNow);

    /// <summary>
    ///     Creates the notification email for the specified job offer and user.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <param name="user"> The user. </param>
    /// <returns> The email subject and body. </returns>
    internal abstract (string subject, string body) CreateNotificationEmail(JobOffer jobOffer, User user);

    /// <summary>
    ///     Represents the day before notification type.
    /// </summary>
    private class DayBeforeNotificationType : NotificationType
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotificationType.DayBeforeNotificationType" /> class.
        /// </summary>
        public DayBeforeNotificationType()
            : base(1, "Day before") { }

        /// <inheritdoc />
        public override Maybe<Notification> TryCreateNotification(JobOffer jobOffer, Guid userId, DateTime utcNow)
        {
            const int allowedDifferenceInDays = 1;

            if ((jobOffer.DateTimeUtc - utcNow).Days < allowedDifferenceInDays) return Maybe<Notification>.None;

            return new Notification(jobOffer.Id, userId, this, jobOffer.DateTimeUtc.AddDays(-allowedDifferenceInDays));
        }

        /// <inheritdoc />
        internal override (string subject, string body) CreateNotificationEmail(JobOffer jobOffer, User user)
        {
            return ($"The job application period for '{jobOffer.Title}' it's almost over! \u23f0",
                    $"Hello {user.FullName}," +
                    Environment.NewLine +
                    Environment.NewLine +
                    $"The job offer '{jobOffer.Title}' is closing its application period in 24 hours.");
        }
    }
}