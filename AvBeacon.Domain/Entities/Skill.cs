using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Entities;

public sealed class Skill : Entity
{
    public Skill(string title)
        : base(Guid.NewGuid())
    {
        Title = title;
    }

    public string Title { get; set; }
    public List<Applicant> Applicants { get; init; } = [];
}