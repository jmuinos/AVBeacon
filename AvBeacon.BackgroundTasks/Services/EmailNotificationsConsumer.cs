using AvBeacon.Application.Abstractions.Common;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Notifications;
using AvBeacon.Contracts.Emails;
using AvBeacon.Domain.Notifications;

namespace AvBeacon.BackgroundTasks.Services;

/// <summary>
///     Represents the email notifications consumer.
/// </summary>
internal sealed class EmailNotificationsConsumer : IEmailNotificationsConsumer
{
    private readonly IDateTime _dateTime;
    private readonly IEmailNotificationService _emailNotificationService;
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EmailNotificationsConsumer" /> class.
    /// </summary>
    /// <param name="notificationRepository"> The notification repository. </param>
    /// <param name="unitOfWork"> The unit of work. </param>
    /// <param name="dateTime"> The date and time. </param>
    /// <param name="emailNotificationService"> The email notification service. </param>
    public EmailNotificationsConsumer(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork,
        IDateTime dateTime,
        IEmailNotificationService emailNotificationService)
    {
        _notificationRepository   = notificationRepository;
        _unitOfWork               = unitOfWork;
        _dateTime                 = dateTime;
        _emailNotificationService = emailNotificationService;
    }

    /// <inheritdoc />
    public async Task ConsumeAsync(
        int batchSize,
        int allowedNotificationTimeDiscrepancyInMinutes,
        CancellationToken cancellationToken = default)
    {
        var notificationsToBeSent =
            await _notificationRepository.GetNotificationsToBeSentIncludingUserAndJobOffer(
                batchSize,
                _dateTime.UtcNow,
                allowedNotificationTimeDiscrepancyInMinutes);

        var sendNotificationEmailTasks = new List<Task>();

        foreach (var (notification, jobOffer, user) in notificationsToBeSent)
        {
            var result = notification.MarkAsSent();

            if (result.IsFailure) continue;

            _notificationRepository.Update(notification);

            var (subject, body) = notification.CreateNotificationEmail(jobOffer, user);

            var notificationEmail = new NotificationEmail(user.Email, subject, body);

            sendNotificationEmailTasks.Add(_emailNotificationService.SendNotificationEmail(notificationEmail));
        }

        await Task.WhenAll(sendNotificationEmailTasks);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}