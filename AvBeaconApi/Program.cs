using AvBeacon.Application;
using AvBeacon.Application.Applicants.Queries.GetAll;
using AvBeacon.Application.Authentication.Login.Commands;
using AvBeacon.Application.Authentication.Update;
using AvBeacon.Application.Users.Commands.Create;
using AvBeacon.Contracts.Requests;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Infrastructure;
using AvBeacon.Persistence;
using AvBeaconApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpContextAccessor(); // Añadir el acceso al contexto HTTP

// Servicios de las capas de la aplicación
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration);

// Autorización
builder.Services.AddAuthorization();

// Swagger & OpenAPI
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUiOptions => swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "AvBeacon API"));
}

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

#region Authentication Endpoints

app.MapPost("/login",
        async (LoginUserRequest loginUserRequest, IMediator mediator) =>
        {
            return await Result.Create(loginUserRequest, DomainErrors.General.UnProcessableRequest)
                .Map(request => new LoginCommand(request.Email, request.Password))
                .Bind(command => mediator.Send(command))
                .Match(success => Results.Ok(success),
                    error => Results.BadRequest(new { error.Code, error.Message }));
        })
    .Produces<TokenResponse>()
    .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
    .WithName("Login")
    .WithOpenApi();

app.MapPost("/register",
        async (RegisterUserRequest registerRequest, IMediator mediator) =>
        {
            return await Result.Create(registerRequest, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateUserCommand(request.FirstName,
                    request.LastName,
                    request.Email,
                    request.Password,
                    request.UserType))
                .Bind(command => mediator.Send(command))
                .Match(success => Results.Ok(success),
                    error => Results.BadRequest(new { error.Code, error.Message }));
        })
    .Produces<TokenResponse>()
    .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
    .WithName("Register")
    .WithOpenApi();

#endregion

#region User Endpoints

app.MapPut("/users/user/update{userId:guid}",
        async (Guid userId, UpdateUserRequest request, IMediator mediator) =>
        {
            return await Result.Create(request, DomainErrors.General.UnProcessableRequest)
                .Ensure(req => req.UserId == userId, DomainErrors.General.UnProcessableRequest)
                .Map(req => new UpdateUserCommand(req.UserId, req.FirstName, req.LastName))
                .Bind(command => mediator.Send(command))
                .Match(Results.Ok,
                    error => Results.BadRequest(new { error.Code, error.Message }));
        })
    .Produces(StatusCodes.Status200OK)
    .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
    .WithName("UpdateUser")
    .WithTags("Users")
    .WithOpenApi();

#endregion

#region Applicants

app.MapGet("/applicants",
        async (IMediator mediator) =>
        {
            var result = await Maybe<GetAllApplicantsQuery>.From(new GetAllApplicantsQuery())
                .Bind(query => mediator.Send(query))
                .Match(success => Results.Ok(success), () => Results.NotFound());
            return result;
        })
    .Produces<List<Maybe<UserResponse>>>()
    .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
    .WithName("GetAllApplicants")
    .WithTags("Applicants")
    .WithOpenApi();

#endregion

app.Run();