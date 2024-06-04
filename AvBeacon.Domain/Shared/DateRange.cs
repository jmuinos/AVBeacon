using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Shared;

public sealed class DateRange : ValueObject
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="DateRange" /></summary>
    /// <param name="start">El valor de la fecha inicial.</param>
    /// <param name="end">El valor de la fecha final.</param>
    public DateRange(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
        DaysPassed = end.DayNumber - start.DayNumber;
    }

    public DateRange()
    {
    }

    private DateOnly Start { get; }
    private DateOnly End { get; }

    public int DaysPassed { get; set; }


    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Start;
        yield return End;
    }
}