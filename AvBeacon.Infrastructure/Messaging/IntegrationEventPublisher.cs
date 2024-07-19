﻿using System.Text;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Infrastructure.Messaging.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace AvBeacon.Infrastructure.Messaging
{
    /// <summary>
    /// Represents the integration event publisher.
    /// </summary>
    internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher, IDisposable
    {
        private readonly MessageBrokerSettings _messageBrokerSettings;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationEventPublisher"/> class.
        /// </summary>
        /// <param name="messageBrokerSettingsOptions">The message broker settings options.</param>
        public IntegrationEventPublisher(IOptions<MessageBrokerSettings> messageBrokerSettingsOptions)
        {
            _messageBrokerSettings = messageBrokerSettingsOptions.Value;
            
            IConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = _messageBrokerSettings.HostName,
                Port = _messageBrokerSettings.Port,
                UserName = _messageBrokerSettings.UserName,
                Password = _messageBrokerSettings.Password
            };

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(_messageBrokerSettings.QueueName, false, false, false);
        }

        /// <inheritdoc />
        public void Publish(IIntegrationEvent integrationEvent)
        {
            var payload = JsonConvert.SerializeObject(integrationEvent, typeof(IIntegrationEvent), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            var body = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(string.Empty, _messageBrokerSettings.QueueName, body: body);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }
    }
}
