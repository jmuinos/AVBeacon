using AvBeacon.Contracts.Emails;

namespace AvBeacon.Application.Abstractions.Notifications
{
    /// <summary>
    /// Represents the email notification service interface.
    /// </summary>
    public interface IEmailNotificationService
    {
        /// <summary>
        /// Sends the welcome email notification based on the specified request.
        /// </summary>
        /// <param name="welcomeEmail">The welcome email.</param>
        /// <returns>The completed task.</returns>
        Task SendWelcomeEmail(WelcomeEmail welcomeEmail);

        /// <summary>
        /// Sends the job application sent email.
        /// </summary>
        /// <param name="jobApplicationCreatedEmail">The job application sent email.</param>
        /// <returns>The completed task.</returns>
        Task SendFriendshipRequestSentEmail(JobApplicationCreatedEmail jobApplicationCreatedEmail);

        /// <summary>
        /// Sends the job application accepted email.
        /// </summary>
        /// <param name="jobApplicationProcessedEmail">The job application accepted email.</param>
        /// <returns>The completed task.</returns>
        Task SendFriendshipRequestAcceptedEmail(JobApplicationProcessedEmail jobApplicationProcessedEmail);
        
        /// <summary>
        /// Sends the job offer published email.
        /// </summary>
        /// <param name="jobOfferCreatedEmail">The job offer published email.</param>
        /// <returns>The completed task.</returns>
        Task SendFriendshipRequestAcceptedEmail(JobOfferCreatedEmail jobOfferCreatedEmail);

        /// <summary>
        /// Sends the password changed email.
        /// </summary>
        /// <param name="passwordChangedEmail">The password changed email.</param>
        /// <returns>The completed task.</returns>
        Task SendPasswordChangedEmail(PasswordChangedEmail passwordChangedEmail);

        /// <summary>
        /// Sends the notification email.
        /// </summary>
        /// <param name="notificationEmail">The notification email.</param>
        /// <returns>The completed task.</returns>
        Task SendNotificationEmail(NotificationEmail notificationEmail);
    }
}
