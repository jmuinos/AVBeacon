using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain.Repositories;
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApplicantRepository, ApplicantRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<IRecruiterRepository, RecruiterRepository>();
        services.AddScoped<IJobOfferRepository, JobOfferRepository>();

        return services;
    }
}