using AvBeacon.Domain.Applicants;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

public class ApplicantRepository(ApplicationDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    public async Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(a => EF.Functions.Like(a.FirstName, $"%{nameText}%") ||
                                EF.Functions.Like(a.LastName, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }

    public async Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }
}