using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class ApplicantRepository(ApplicationDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    public async Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }

    public async Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(a => EF.Functions.Like(a.FirstName, $"%{nameText}%") ||
                                EF.Functions.Like(a.LastName, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }
}