using System.Reflection;
using System.Text.Json.Serialization;
using AvBeacon.Application._Core.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AvBeacon.Application;

public static class DependencyInjection
{
    /// <summary> Registra los servicios necesarios mediante inyección de dependencias. </summary>
    /// <param name="services"> La colección de servicios. </param>
    /// <returns> La misma colección de servicios. </returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));

        return services;
    }
}