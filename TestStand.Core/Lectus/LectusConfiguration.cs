using TestStand.Lib.Modbus;

namespace TestStand.Core.Lectus;

public class LectusConfiguration
{
    public required ModbusConfiguration ModbusConfiguration { get; init; }
}