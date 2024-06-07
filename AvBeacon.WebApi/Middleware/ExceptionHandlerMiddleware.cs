using System.Net;
using System.Text.Json;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Exceptions;
using AvBeacon.WebApi.Errors;
using ValidationException = AvBeacon.Application._Core.Exceptions.ValidationException;

namespace AvBeacon.WebApi.Middleware;

internal class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    /// <summary>Inicializa una nueva instancia de la clase <see cref="ExceptionHandlerMiddleware" />.</summary>
    /// <param name="next">El delegado que apunta al siguiente middleware en la cadena.</param>
    /// <param name="logger">El registrador.</param>
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>Invoca el middleware del manejador de excepciones con el <see cref="HttpContext" /> especificado.</summary>
    /// <param name="httpContext">El HttpContext HTTP.</param>
    /// <returns>La tarea que puede ser esperada por el siguiente middleware.</returns>
    public async Task Invoke(HttpContext httpContext)
    {
        try { await _next(httpContext); }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    /// <summary> Maneja la <see cref="Exception" /> especificada para el <see cref="HttpContext" /> especificado. </summary>
    /// <param name="httpContext">El HttpContext HTTP.</param>
    /// <param name="exception">La excepción.</param>
    /// <returns>La respuesta HTTP que se modifica en función de la excepción.</returns>
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var (httpStatusCode, errors) = GetHttpStatusCodeAndErrors(exception);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)httpStatusCode;

        var serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var response = JsonSerializer.Serialize(new ApiErrorResponse(errors), serializerOptions);

        await httpContext.Response.WriteAsync(response);
    }

    private static (HttpStatusCode httpStatusCode, IReadOnlyCollection<Error>)
        GetHttpStatusCodeAndErrors(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => (HttpStatusCode.BadRequest, validationException.Errors),
            DomainException domainException => (HttpStatusCode.BadRequest, new[] { domainException.Error }),
            _ => (HttpStatusCode.InternalServerError, new[] { DomainErrors.General.ServerError })
        };
    }
}

/// <summary> Contiene métodos de extensión para configurar el middleware del manejador de excepciones. </summary>
internal static class ExceptionHandlerMiddlewareExtensions
{
    /// <summary> Configura el middleware del handler de excepciones personalizado. </summary>
    /// <param name="builder"> El constructor de la aplicación. </param>
    /// <returns> El constructor de la aplicación configurado. </returns>
    internal static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}