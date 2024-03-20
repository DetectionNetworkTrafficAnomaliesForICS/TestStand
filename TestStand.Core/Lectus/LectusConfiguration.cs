using TestStand.Lib.Modbus;
using TestStand.Lib.Model;

namespace TestStand.Core.Lectus;

public class LectusConfiguration
{
    public required ModbusConfiguration ModbusConfiguration { get; init; }
    public required Register OscilloscopeV { get; init; }
}