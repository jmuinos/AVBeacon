using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class ApplicantRepository(ApplicationDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    public async Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await Context.Applicants.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }

    public async Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await Context.Applicants
                            .Where(a => EF.Functions.Like(a.FirstName, $"%{nameText}%") ||
                                        EF.Functions.Like(a.LastName, $"%{nameText}%"))
                            .ToListAsync(cancellationToken);
    }

    public async Task<Result> AddSkillAsync(Guid applicantId, Guid skillId,
        CancellationToken cancellationToken = default)
    {
        var applicant = await Context.Applicants
                                     .Include(applicant => applicant.Skills)
                                     .FirstOrDefaultAsync(a => a.Id == applicantId, cancellationToken);
        if (applicant == null)
            return Result.Failure(DomainErrors.Applicant.NotFound);

        var skill = await Context.Skills.FindAsync(new object[] { skillId }, cancellationToken);
        if (skill == null)
            return Result.Failure(DomainErrors.Skill.NotFound);

        if (!applicant.Skills.Contains(skill))
            applicant.Skills.Add(skill);

        if (!skill.Applicants.Contains(applicant))
            skill.Applicants.Add(applicant);

        Context.Applicants.Update(applicant);
        Context.Skills.Update(skill);

        await Context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}