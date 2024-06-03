using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.Experiences;

/// <summary>Representa una experiencia profesional de un candidato.</summary>
public sealed class Experience : Entity
{
    public Description? Description { get; set; }

    public Title? Title { get; set; }
    public Name? RecruiterName { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }

    #region Constructors

    public Experience(Guid id, Title? title, Description? description, Name? recruiterName, DateTime? start,
                      DateTime? end)
        : base(id)
    {
        Title = title;
        Description = description;
        RecruiterName = recruiterName;
        Start = start;
        End = end;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Experience" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Experience() { }

    #endregion
}