namespace AvBeacon.Contracts.Educations
{
    /// <summary> Representa la respuesta de la educación. </summary>
    public sealed record EducationResponse
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required string EducationType { get; init; }
    }
}