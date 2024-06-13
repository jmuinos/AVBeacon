using AvBeacon.Application._Core.Abstractions.Common;

namespace AvBeacon.Infrastructure.Common;

internal sealed class MachineDateTime : IDateTime
{
    /// <inheritdoc />
    public DateTime UtcNow => DateTime.UtcNow;
}