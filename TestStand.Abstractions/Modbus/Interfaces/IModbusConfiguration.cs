using TestStand.Abstractions.Device.Interfaces;
using TestStand.Abstractions.Net.Interfaces;
using TestStand.Abstractions.Register.Interfaces;

namespace TestStand.Abstractions.Modbus.Interfaces;

public interface IModbusConfiguration
{
    ulong Id { get; }
    public ISetRegisters Registers { get; }
    public INetService NetService { get; }
}