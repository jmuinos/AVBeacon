namespace AvBeacon.Infrastructure.Migrations;

public class Skill
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Applicants { get; set; } = new List<User>();
}