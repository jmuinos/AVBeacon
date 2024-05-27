using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa un usuario de tipo candidato.</summary>
public sealed class Candidate : User
{
    #region Constructors

    public Candidate(
        Guid id, Email email, FirstName firstName, LastName lastName,
        List<Education>? educations, List<Experience>? experiences, List<Skill>? skills)
        : base(id, email, firstName, lastName)
    {
        Educations = educations;
        Experiences = experiences;
        Skills = skills;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Candidate" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Candidate()
    {
    }

    #endregion

    #region Properties

    public List<Education>? Educations { get; private set; }
    public List<Experience>? Experiences { get; private set; }
    public List<Skill>? Skills { get; private set; }

    #endregion
}