namespace AvBeacon.Domain.Entities;

public class Candidate : User
{
    public List<Experience>? Experiences { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<Education>? Educations { get; set; }
}