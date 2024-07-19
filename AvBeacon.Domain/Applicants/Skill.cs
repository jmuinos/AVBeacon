using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Applicants;

public sealed class Skill : Entity
{
    public Skill(Title title) : base(Guid.NewGuid()) { Title = title; }

    public Title Title { get; set; }

// En Skill
    public ICollection<Applicant> Applicants { get; private set; } = new List<Applicant>();
}