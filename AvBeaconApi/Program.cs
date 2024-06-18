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
using AvBeaconApi.Identity;
using AvBeaconApi.Middleware;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddHttpContextAccessor(); // Add HTTP context accessor

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
// Application layers services
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration);

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityData.AdminUserPolicyName,
        policy => policy.RequireClaim(IdentityData.AdminUserClaimName, "true"));

    options.AddPolicy(IdentityData.GeneralUserPolicyName,
        policy => policy.RequireClaim(IdentityData.GeneralUserClaimName, "true"));

    options.AddPolicy(IdentityData.RecruiterUserPolicyName,
        policy => policy.RequireClaim(IdentityData.RecruiterUserClaimName, "true"));

    options.AddPolicy(IdentityData.ApplicantUserPolicyName,
        policy => policy.RequireClaim(IdentityData.ApplicantUserClaimName, "true"));
});

// Swagger & OpenAPI
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline
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
                .Match(Results.Ok, error => Results.BadRequest(new { error.Code, error.Message }));
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
                .Match(Results.Ok, error => Results.BadRequest(new { error.Code, error.Message }));
        })
    .Produces<TokenResponse>()
    .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
    .WithName("Register")
    .WithOpenApi();

#endregion

#region User Endpoints

app.MapPut("/users/user/update/{userId:guid}",
        async (Guid userId, UpdateUserRequest updateUserRequest, IMediator mediator) =>
        {
            return await Result.Create(updateUserRequest, DomainErrors.General.UnProcessableRequest)
                .Ensure(request => request.UserId == userId, DomainErrors.General.UnProcessableRequest)
                .Map(request => new UpdateUserCommand(request.UserId, request.FirstName, request.LastName))
                .Bind<UpdateUserCommand, Result>(async command => await mediator.Send(command))
                .Match<Result, IResult>(
                    onSuccess: success => Results.Ok(),
                    onFailure: error => Results.BadRequest(new { error.Code, error.Message })
                );
        })
    .Produces(StatusCodes.Status200OK)
    .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
    .WithName("UpdateUser")
    .WithTags("Users")
    .WithOpenApi();

#endregion

#region Applicant Endpoints

app.MapGet("/applicants",
        async (IMediator mediator) =>
        {
            var result = await Maybe<GetAllApplicantsQuery>.From(new GetAllApplicantsQuery())
                .Bind(query => mediator.Send(query))
                .Match(Results.Ok, () => Results.NotFound());
            return result;
        })
    .Produces<List<Maybe<UserResponse>>>()
    .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
    .WithName("GetAllApplicants")
    .WithTags("Applicants")
    .WithOpenApi();

#endregion

app.Run();