namespace TestStand.Lib.Device.Interfaces;

public interface ILifeCycleDevice
{
    Task Setup();
    Task Shutdown();
}