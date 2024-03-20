using TestStand.Core.Register;
using TestStand.Lib.Modbus;

using TestStand.Lib.Register;


namespace TestStand.Core.Lectus;

public class LectusConfiguration
{
    public required ModbusConfiguration ModbusConfiguration { get; init; }
    public required FloatRegister OscilloscopeV { get; init; }
}