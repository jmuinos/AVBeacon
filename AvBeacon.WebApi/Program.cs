using AvBeacon.Application._Core;
using AvBeacon.Application.Applicants.Commands;
using AvBeacon.Application.Educations.Commands;
using AvBeacon.Application.Experiences.Commands.CreateExperience;
using AvBeacon.Application.JobApplications.Commands.CreateJobApplication;
using AvBeacon.Application.JobApplications.Queries;
using AvBeacon.Application.JobOffers.Commands.CreateJobOffer;
using AvBeacon.Application.JobOffers.Commands.UpdateJobOffer;
using AvBeacon.Application.Recruiters.Commands.CreateRecruiter;
using AvBeacon.Domain.Entities;
using AvBeacon.Infrastructure;
using AvBeacon.WebApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
       .AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection") ??
                          throw new InvalidOperationException("ConnectionString inválido."));

// Añadir servicios de Identity
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// // Configurar los servicios
// builder.Services.AddControllers()
//        .AddJsonOptions(options =>
//         { options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve; });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<ExceptionHandlerMiddleware>();


// Minimal API Endpoints
app.MapPost("/register/applicant", async (CreateApplicantCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.MapPost("/register/recruiter", async (CreateRecruiterCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.MapPost("/jobapplication/create", async (CreateJobApplicationCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.MapGet("/jobapplications/applicant/{applicantId}", async (Guid applicantId, IMediator mediator) =>
{
    var query = new GetJobApplicationsByApplicantIdQuery { ApplicantId = applicantId };
    var result = await mediator.Send(query);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.MapPost("/joboffer/create", async (CreateJobOfferCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.MapPost("/joboffer/update", async (UpdateJobOfferCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok();
    return Results.BadRequest(result.Error);
});

app.MapPost("/applicant/add-skill", async (AddApplicantSkillCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);
});

app.MapPost("/experience/create", async (CreateExperienceCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.MapPost("/education/create", async (CreateEducationCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    if (result.IsSuccess) return Results.Ok(result);
    return Results.BadRequest(result.Error);
});

app.Run();