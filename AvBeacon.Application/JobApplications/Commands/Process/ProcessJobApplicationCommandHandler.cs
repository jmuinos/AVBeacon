using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.JobApplications.Commands.Process
{
    /// <summary> Representa el handler de comandos para <see cref="ProcessJobApplicationCommand" />. </summary>
    internal sealed class ProcessJobApplicationCommandHandler : ICommandHandler<ProcessJobApplicationCommand, Result>
    {
        private readonly IDbContext _dbContext;

        /// <summary> Inicializa una nueva instancia de la clase <see cref="ProcessJobApplicationCommandHandler" />. </summary>
        /// <param name="dbContext"> El contexto de base de datos. </param>
        public ProcessJobApplicationCommandHandler(IDbContext dbContext) { _dbContext = dbContext; }

        /// <inheritdoc />
        public async Task<Result> Handle(ProcessJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var maybeJobApplication = await _dbContext.GetByIdAsync<JobApplication>(request.JobApplicationId);

        if (maybeJobApplication.HasNoValue)
            return Result.Failure(DomainErrors.JobApplication.NotFound);

        var jobApplication = maybeJobApplication.Value;

        if (request.State != "Accepted" && request.State != "Denied")
            return Result.Failure(DomainErrors.General.UnProcessableRequest);

        jobApplication.State = request.State == "Accepted" ? JobApplicationState.Accepted : JobApplicationState.Denied;

        return Result.Success();
    }
    }
}