using System.Text.Json;
using System.Text.Json.Serialization;
using AvBeacon.Application;
using AvBeacon.Application.Applicants.Commands.CreateApplicantSkill;
using AvBeacon.Application.Applicants.Queries.GetAll;
using AvBeacon.Application.Authentication.Login.Commands;
using AvBeacon.Application.Authentication.Update;
using AvBeacon.Application.Users.Commands.Create;
using AvBeacon.Contracts.Requests;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Infrastructure;
using AvBeacon.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

// Añadir servicios de layers
builder.Services
       .AddApplication()
       .AddInfrastructure(builder.Configuration)
       .AddPersistence(builder.Configuration);

// Configurar los servicios
builder.Services.AddControllers()
       .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.MaxDepth = 64;
        });

// Configura Fluent Validation
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EventReminder API",
        Version = "v1"
    });

    swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configura autorización
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApplicantOnly", policy => policy.RequireClaim("UserType", "Applicant"));
    options.AddPolicy("RecruiterOnly", policy => policy.RequireClaim("UserType", "Recruiter"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUiOptions =>
                         swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "AvBeaconAPI"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();

#region Authentication Endpoints

app.MapPost("/login", async (LoginUserRequest loginUserRequest, IMediator mediator) =>
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
   .WithTags("Authentication");

app.MapPost("/register", async (RegisterUserRequest registerRequest, IMediator mediator) =>
    {
        return await Result.Create(registerRequest, DomainErrors.General.UnProcessableRequest)
                           .Map(request => new CreateUserCommand(request.FirstName, request.LastName, request.Email,
                                                                 request.Password, request.UserType))
                           .Bind(command => mediator.Send(command))
                           .Match(success => Results.Ok(success),
                                  error => Results.BadRequest(new { error.Code, error.Message }));
    })
   .Produces<TokenResponse>()
   .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
   .WithName("Register")
   .WithTags("Authentication");

#endregion

#region User Endpoints

app.MapPut("/user/update{userId:guid}", async (Guid userId, UpdateUserRequest request, IMediator mediator) =>
    {
        return await Result.Create(request, DomainErrors.General.UnProcessableRequest)
                           .Ensure(req => req.UserId == userId, DomainErrors.General.UnProcessableRequest)
                           .Map(req => new UpdateUserCommand(req.UserId, req.FirstName, req.LastName))
                           .Bind(command => mediator.Send(command))
                           .Match(success => Results.Ok(),
                                  error => Results.BadRequest(new { error.Code, error.Message }));
    })
   .Produces(StatusCodes.Status200OK)
   .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
   .WithName("UpdateUser")
   .WithTags("Users");

#endregion

#region Applicants

app.MapPost("/user/add-skill/{userId:guid}&{skillId:guid}",
            async (Guid applicantId, Guid skillId, AddApplicantSkillRequest request, IMediator mediator) =>
            {
                request.ApplicantId = applicantId;
                request.SkillId = skillId;
                return await Result.Create(request, DomainErrors.General.UnProcessableRequest)
                                   .Ensure(req => applicantId != Guid.Empty, DomainErrors.General.UnProcessableRequest)
                                   .Ensure(req => skillId != Guid.Empty, DomainErrors.General.UnProcessableRequest)
                                   .Map(req => new AddApplicantSkillCommand(req.ApplicantId, req.SkillId))
                                   .Bind(command => mediator.Send(command))
                                   .Match(success => Results.Ok(success),
                                          error => Results.BadRequest(new Error(error.Code, error.Message)));
            })
   .Produces(StatusCodes.Status200OK)
   .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
   .WithName("AddApplicantSkill")
   .WithTags("ApplicantSkills");

app.MapGet("/applicants", async (IMediator mediator) =>
    {
        var result = await Maybe<GetAllApplicantsQuery>.From(new GetAllApplicantsQuery())
                                                       .Bind(query => mediator.Send(query))
                                                       .Match(success => Results.Ok(success), () => Results.NotFound());
        return result;
    })
   .Produces<List<Maybe<UserResponse>>>(StatusCodes.Status200OK)
   .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
   .WithName("GetAllApplicants")
   .WithTags("Applicants");

#endregion