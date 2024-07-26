namespace AvBeacon.Contracts.Skills
{
    public sealed record ApplicantSkillRequest
    {
        public Guid ApplicantId { get; set; }
        public Guid SkillId { get; set; }
    }
}