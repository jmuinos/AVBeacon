using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class RecruiterRepository(ApplicationDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository
{
    public async Task<Recruiter?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(r => r.Email == email, cancellationToken);
    }

    public async Task<List<Recruiter>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(r => EF.Functions.Like(r.FirstName, $"%{nameText}%") ||
                                EF.Functions.Like(r.LastName, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }
}