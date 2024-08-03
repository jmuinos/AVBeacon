using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Users.Applicants.JobApplications;

namespace AvBeacon.Application.Commands.Users.Recruiters.ProcessJobApplication;

/// <summary>
///     Representa el handler de comandos para <see cref="ProcessJobApplicationCommand" />.
/// </summary>
internal sealed class ProcessJobApplicationCommandHandler : ICommandHandler<ProcessJobApplicationCommand, Result>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="ProcessJobApplicationCommandHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public ProcessJobApplicationCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(ProcessJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var maybeJobApplication = await _dbContext.GetByIdAsync<JobApplication>(request.JobApplicationId);

        if (maybeJobApplication.HasNoValue)
            return Result.Failure(DomainErrors.JobApplications.NotFound);

        var jobApplication = maybeJobApplication.Value;

        if (request.State != "Accepted" && request.State != "Rejected")
            return Result.Failure(DomainErrors.General.UnProcessableRequest);

        jobApplication.ChangeState(JobApplicationState.FromString(request.State));

        return Result.Success();
    }
}