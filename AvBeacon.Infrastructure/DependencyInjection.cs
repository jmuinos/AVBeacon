using System.Text;
using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Common;
using AvBeacon.Application.Abstractions.Cryptography;
using AvBeacon.Application.Abstractions.Emails;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Application.Abstractions.Notifications;
using AvBeacon.Domain.Users;
using AvBeacon.Infrastructure.Authentication;
using AvBeacon.Infrastructure.Authentication.Settings;
using AvBeacon.Infrastructure.Common;
using AvBeacon.Infrastructure.Cryptography;
using AvBeacon.Infrastructure.Emails;
using AvBeacon.Infrastructure.Emails.Settings;
using AvBeacon.Infrastructure.Messaging;
using AvBeacon.Infrastructure.Messaging.Settings;
using AvBeacon.Infrastructure.Notifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AvBeacon.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
                });

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));

            services.Configure<MailSettings>(configuration.GetSection(MailSettings.SettingsKey));

            services.Configure<MessageBrokerSettings>(configuration.GetSection(MessageBrokerSettings.SettingsKey));

            services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();

            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddTransient<IDateTime, MachineDateTime>();

            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddTransient<IPasswordHashChecker, PasswordHasher>();

            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<IEmailNotificationService, EmailNotificationService>();

            services.AddSingleton<IIntegrationEventPublisher, IntegrationEventPublisher>();

            return services;
        }
    }
}
