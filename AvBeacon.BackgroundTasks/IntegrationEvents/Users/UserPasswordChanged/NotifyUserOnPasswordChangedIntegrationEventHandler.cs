using AvBeacon.Application.Abstractions.Notifications;
using AvBeacon.Application.Users.ChangePassword;
using AvBeacon.BackgroundTasks.Abstractions.Messaging;
using AvBeacon.Contracts.Emails;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Exceptions;
using AvBeacon.Domain.Users;

namespace AvBeacon.BackgroundTasks.IntegrationEvents.Users.UserPasswordChanged;

/// <summary>
///     Represents the <see cref="UserPasswordChangedIntegrationEvent" /> handler.
/// </summary>
internal sealed class NotifyUserOnPasswordChangedIntegrationEventHandler
    : IIntegrationEventHandler<UserPasswordChangedIntegrationEvent>
{
    private readonly IEmailNotificationService _emailNotificationService;
    private readonly IUserRepository _userRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="NotifyUserOnPasswordChangedIntegrationEventHandler" /> class.
    /// </summary>
    /// <param name="userRepository"> The user repository. </param>
    /// <param name="emailNotificationService"> The email notification service. </param>
    public NotifyUserOnPasswordChangedIntegrationEventHandler(
        IUserRepository userRepository,
        IEmailNotificationService emailNotificationService)
    {
        _emailNotificationService = emailNotificationService;
        _userRepository           = userRepository;
    }

    /// <inheritdoc />
    public async Task Handle(UserPasswordChangedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var maybeUser = await _userRepository.GetByIdAsync(notification.UserId);

        if (maybeUser.HasNoValue) throw new DomainException(DomainErrors.Users.NotFound);

        var user = maybeUser.Value;

        var passwordChangedEmail = new PasswordChangedEmail(user.Email, user.FullName);

        await _emailNotificationService.SendPasswordChangedEmail(passwordChangedEmail);
    }
}