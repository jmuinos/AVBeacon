using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Users;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Primitives.Maybe;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Applicants.Queries.GetAll
{
    /// <summary> Representa el manejador de la consulta <see cref="GetAllApplicantsQuery" />. </summary>
    internal sealed class GetAllApplicantsQueryHandler : IQueryHandler<GetAllApplicantsQuery, Maybe<List<UserResponse>>>
    {
        private readonly IDbContext _dbContext;

        /// <summary> Inicializa una nueva instancia de la clase <see cref="GetAllApplicantsQueryHandler" />. </summary>
        /// <param name="dbContext"> El contexto de base de datos. </param>
        public GetAllApplicantsQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

        /// <inheritdoc />
        public async Task<Maybe<List<UserResponse>>> Handle(GetAllApplicantsQuery request,
            CancellationToken cancellationToken)
        {
            var applicants = await _dbContext.Set<Applicant>()
                .Select(applicant => new UserResponse
                {
                    Id = applicant.Id,
                    FirstName = applicant.FirstName.Value,
                    LastName = applicant.LastName.Value,
                    FullName = applicant.FullName,
                    Email = applicant.Email.Value
                })
                .ToListAsync(cancellationToken);
            return applicants;
        }
    }
}