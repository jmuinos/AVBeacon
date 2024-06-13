namespace AvBeacon.Domain.Entities;

public class ApplicantSkill
{
    public Guid ApplicantId { get; init; }
    public Guid SkillId { get; init; }
    public Applicant Applicant { get; init; } = null!;
    public Skill Skill { get; init; } = null!;
}