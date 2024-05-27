using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa un usuario de tipo reclutador.</summary>
public sealed class Recruiter : User
{
    #region Constructors

    public Recruiter(Guid id, Email email, FirstName firstName, LastName lastName, List<JobOffer>? jobOffers)
        : base(id, email, firstName, lastName)
    {
        JobOffers = jobOffers;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Recruiter" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Recruiter()
    {
    }

    #endregion

    #region Properties

    public List<JobOffer>? JobOffers { get; private set; }

    #endregion
}