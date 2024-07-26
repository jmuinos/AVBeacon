namespace AvBeacon.Infrastructure.Messaging.Settings
{
    /// <summary>
    /// Represents the message broker settings.
    /// </summary>
    public sealed class MessageBrokerSettings
    {
        public const string SettingsKey = "MessageBroker";

        /// <summary>
        /// Gets or sets the host name.
        /// </summary>
        public required string HostName { get; init; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public required string UserName { get; init; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public required string Password { get; init; }

        /// <summary>
        /// Gets or sets the queue name.
        /// </summary>
        public required string QueueName { get; init; }
    }
}
