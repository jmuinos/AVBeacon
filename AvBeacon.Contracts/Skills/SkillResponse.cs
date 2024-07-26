namespace AvBeacon.Contracts.Skills
{
    /// <summary> Representa la respuesta de una habilidad. </summary>
    public sealed class SkillResponse
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
    }
}