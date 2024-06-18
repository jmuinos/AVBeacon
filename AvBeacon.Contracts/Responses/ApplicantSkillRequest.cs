namespace AvBeacon.Contracts;

public sealed record ApplicantSkillRequest
{
    public Guid ApplicantId { get; set; }
    public Guid SkillId { get; set; }
}