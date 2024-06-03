using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.Skills;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Candidates;

/// <summary>Representa un usuario de tipo candidato.</summary>
public sealed class Candidate(
    Guid id,
    Email email,
    FirstName firstName,
    LastName lastName,
    List<Education>? educations,
    List<Experience>? experiences,
    List<Skill>? skills)
    : User(id, email, firstName, lastName)
{
    public List<Education>? Educations { get; private set; } = educations;
    public List<Experience>? Experiences { get; private set; } = experiences;
    public List<Skill>? Skills { get; private set; } = skills;

}