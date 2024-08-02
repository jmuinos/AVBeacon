using System.Reflection;
using AvBeacon.BackgroundTasks.Services;
using AvBeacon.BackgroundTasks.Settings;
using AvBeacon.BackgroundTasks.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvBeacon.BackgroundTasks;

public static class DependencyInjection
{
    /// <summary>
    ///     Registers the necessary services with the DI framework.
    /// </summary>
    /// <param name="services"> The service collection. </param>
    /// <param name="configuration"> The configuration. </param>
    /// <returns> The same service collection. </returns>
    public static IServiceCollection AddBackgroundTasks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.Configure<BackgroundTaskSettings>(configuration.GetSection(BackgroundTaskSettings.SettingsKey));

        services.AddHostedService<EmailNotificationConsumerBackgroundService>();

        services.AddHostedService<IntegrationEventConsumerBackgroundService>();

        services.AddScoped<IEmailNotificationsConsumer, EmailNotificationsConsumer>();

        services.AddScoped<IIntegrationEventConsumer, IntegrationEventConsumer>();

        return services;
    }
}