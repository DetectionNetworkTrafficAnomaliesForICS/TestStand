namespace TestStand.Abstractions.Device.Interfaces;

public interface ILifeCycleDevice
{
    public Task Setup();
    public Task Shutdown();
}