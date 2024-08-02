using AvBeacon.Application.Abstractions.Notifications;
using AvBeacon.Application.Users.CreateUser;
using AvBeacon.BackgroundTasks.Abstractions.Messaging;
using AvBeacon.Contracts.Emails;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Exceptions;
using AvBeacon.Domain.Users;

namespace AvBeacon.BackgroundTasks.IntegrationEvents.Users.UserCreated;

/// <summary>
///     Represents the <see cref="UserCreatedIntegrationEvent" /> handler.
/// </summary>
internal sealed class
    SendWelcomeEmailOnUserCreatedIntegrationEventHandler : IIntegrationEventHandler<UserCreatedIntegrationEvent>
{
    private readonly IEmailNotificationService _emailNotificationService;
    private readonly IUserRepository _userRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SendWelcomeEmailOnUserCreatedIntegrationEventHandler" /> class.
    /// </summary>
    /// <param name="userRepository"> The user repository. </param>
    /// <param name="emailNotificationService"> The email notification service. </param>
    public SendWelcomeEmailOnUserCreatedIntegrationEventHandler(
        IUserRepository userRepository,
        IEmailNotificationService emailNotificationService)
    {
        _emailNotificationService = emailNotificationService;
        _userRepository           = userRepository;
    }

    /// <inheritdoc />
    public async Task Handle(UserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var maybeUser = await _userRepository.GetByIdAsync(notification.UserId);

        if (maybeUser.HasNoValue) throw new DomainException(DomainErrors.Users.NotFound);

        var user = maybeUser.Value;

        var welcomeEmail = new WelcomeEmail(user.Email, user.FullName);

        await _emailNotificationService.SendWelcomeEmail(welcomeEmail);
    }
}