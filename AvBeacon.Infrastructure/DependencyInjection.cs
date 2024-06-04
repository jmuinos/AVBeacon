using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Skills;
using AvBeacon.Domain.Users;
using AvBeacon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AvBeacon.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
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