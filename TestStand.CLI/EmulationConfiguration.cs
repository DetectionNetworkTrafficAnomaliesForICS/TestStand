using TestStand.Abstractions.Configuration.Interfaces;

namespace TestStand.CLI;

public class EmulationConfiguration : IEmulationConfiguration
{
    public long DurationCycle => 10;
}