using TestStand.Abstractions.Net.Interfaces;

namespace TestStand.Abstractions.Device.Interfaces;

public interface IDevice: ILifeCycleDevice
{
    public string Name { get; }
}