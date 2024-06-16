using System.Text;
using System.Text.Json.Serialization;
using AvBeacon.Application._Core.Abstractions.Authentication;
using AvBeacon.Application._Core.Abstractions.Common;
using AvBeacon.Application._Core.Abstractions.Cryptography;
using AvBeacon.Domain.Services;
using AvBeacon.Infrastructure.Authentication;
using AvBeacon.Infrastructure.Authentication.Settings;
using AvBeacon.Infrastructure.Common;
using AvBeacon.Infrastructure.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AvBeacon.Infrastructure;

public static class DependencyInjection
{
    /// <summary> Registers the necessary services with the DI framework. </summary>
    /// <param name="services"> The service collection. </param>
    /// <param name="configuration"> The configuration. </param>
    /// <returns> The same service collection. </returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.SerializerOptions.WriteIndented = true;
        });
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                });
        
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));
        services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddTransient<IDateTime, MachineDateTime>();
        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IPasswordHashChecker, PasswordHasher>();

        return services;
    }
}