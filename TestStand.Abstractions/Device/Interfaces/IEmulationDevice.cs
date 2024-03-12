using TestStand.Abstractions.Cycle.Interfaces;

namespace TestStand.Abstractions.Device.Interfaces;

public interface IEmulationDevice : IDevice, ICycleUpdatable
{
    public ICycleHandlerService HandlerService { get; }
}