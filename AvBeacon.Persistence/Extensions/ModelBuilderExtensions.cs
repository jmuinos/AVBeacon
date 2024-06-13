using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvBeacon.Persistence.Extensions;

/// <summary> Contains extensions methods for the <see cref="ModelBuilder" /> class. </summary>
internal static class ModelBuilderExtensions
{
    private static readonly ValueConverter<DateTime, DateTime> UtcValueConverter =
        new(outside => outside, inside => DateTime.SpecifyKind(inside, DateTimeKind.Utc));

    //TODO: Crear las interfaces IAuditableEntity y ISoftDeletableEntity, 
    /// <summary> Applies the UTC date-time converter to all the properties that are <see cref="DateTime" /> and end with Utc. </summary>
    /// <param name="modelBuilder"> The model builder. </param>
    internal static void ApplyUtcDateTimeConverter(this ModelBuilder modelBuilder)
    {
        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            var dateTimeUtcProperties = mutableEntityType.GetProperties()
                                                         .Where(p => p.ClrType == typeof(DateTime) &&
                                                                     p.Name.EndsWith("Utc", StringComparison.Ordinal));

            foreach (var mutableProperty in dateTimeUtcProperties) mutableProperty.SetValueConverter(UtcValueConverter);
        }
    }
}