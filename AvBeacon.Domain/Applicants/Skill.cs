using AvBeacon.Domain.Common;
using AvBeacon.Domain.Core.Primitives;

namespace AvBeacon.Domain.Applicants;

public sealed class Skill : Entity
{
    public Skill(Title title) : base(Guid.NewGuid())
    {
        Title = title;
    }

    public Title Title { get; private set; }
}