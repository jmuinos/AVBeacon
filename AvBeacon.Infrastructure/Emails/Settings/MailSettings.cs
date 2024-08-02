namespace AvBeacon.Infrastructure.Emails.Settings;

/// <summary>
///     Represents the mail settings.
/// </summary>
public class MailSettings
{
    public const string SettingsKey = "Mail";

    /// <summary>
    ///     Gets or sets the email sender display name.
    /// </summary>
    public required string SenderDisplayName { get; init; }

    /// <summary>
    ///     Gets or sets the email sender.
    /// </summary>
    public required string SenderEmail { get; init; }

    /// <summary>
    ///     Gets or sets the SMTP password.
    /// </summary>
    public required string SmtpPassword { get; init; }

    /// <summary>
    ///     Gets or sets the SMTP server.
    /// </summary>
    public required string SmtpServer { get; init; }

    /// <summary>
    ///     Gets or sets the SMTP port.
    /// </summary>
    public int SmtpPort { get; init; }
}