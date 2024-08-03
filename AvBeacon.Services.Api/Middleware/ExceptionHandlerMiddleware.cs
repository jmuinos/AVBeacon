﻿using System.Net;
using System.Text.Json;
using AvBeacon.Application._Core.Exceptions;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Exceptions;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Services.Api.Contracts;

namespace AvBeacon.Services.Api.Middleware;

/// <summary>
///     Represents the exception handler middleware.
/// </summary>
internal class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ExceptionHandlerMiddleware" /> class.
    /// </summary>
    /// <param name="next"> The delegate pointing to the next middleware in the chain. </param>
    /// <param name="logger"> The logger. </param>
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    /// <summary>
    ///     Invokes the exception handler middleware with the specified <see cref="HttpContext" />.
    /// </summary>
    /// <param name="httpContext"> The HTTP httpContext. </param>
    /// <returns> The task that can be awaited by the next middleware. </returns>
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred: {Message}", ex.Message);

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    /// <summary>
    ///     Handles the specified <see cref="Exception" /> for the specified <see cref="HttpContext" />.
    /// </summary>
    /// <param name="httpContext"> The HTTP httpContext. </param>
    /// <param name="exception"> The exception. </param>
    /// <returns> The HTTP response that is modified based on the exception. </returns>
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var (httpStatusCode, errors) = GetHttpStatusCodeAndErrors(exception);

        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)httpStatusCode;

        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

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

/// <summary>
///     Contains extension methods for configuring the exception handler middleware.
/// </summary>
internal static class ExceptionHandlerMiddlewareExtensions
{
    /// <summary>
    ///     Configure the custom exception handler middleware.
    /// </summary>
    /// <param name="builder"> The application builder. </param>
    /// <returns> The configured application builder. </returns>
    internal static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}