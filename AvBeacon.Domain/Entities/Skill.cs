using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Skill : Entity
{
    public Skill(Title title) : base(Guid.NewGuid()) { Title = title; }

    public Title Title { get; set; }
    public List<Applicant> Applicants { get; } = new();
    public List<ApplicantSkill> ApplicantSkills { get; } = new();
}