using TestStand.Lib.Cycle.Interfaces;

namespace TestStand.Lib.Device.Interfaces;

public interface IEmulationDevice : ILifeCycleDevice, ICycleUpdatable
{
    string Name { get; }
}