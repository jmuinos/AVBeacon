using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Skills;
using AvBeacon.Domain.Users;
using AvBeacon.Domain.Users.Experiences;

namespace AvBeacon.Domain.Applicants;

public sealed class Applicant(
    Guid id,
    string email,
    string firstName,
    string lastName,
    List<Education>? educations,
    List<Experience>? experiences,
    List<Skill>? skills)
    : User(id, email, firstName, lastName)
{
    public List<Education>? Educations { get; private set; } = educations;
    public List<Experience>? Experiences { get; private set; } = experiences;
    public List<Skill>? Skills { get; private set; } = skills;
}