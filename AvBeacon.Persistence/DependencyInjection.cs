using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Applicants.Educations;
using AvBeacon.Domain.Users.Applicants.Experiences;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Applicants.Skills;
using AvBeacon.Domain.Users.Recruiters;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using AvBeacon.Domain.Users.Shared;
using AvBeacon.Persistence.Infrastructure;
using AvBeacon.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvBeacon.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);
        services.AddSingleton(new ConnectionString(connectionString!));
        services.AddDbContext<AvBeaconDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AvBeaconDbContext>());
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AvBeaconDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApplicantRepository, ApplicantRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<IJobOfferRepository, JobOfferRepository>();
        services.AddScoped<IRecruiterRepository, RecruiterRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}