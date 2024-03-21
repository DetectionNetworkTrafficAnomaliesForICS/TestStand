using TestStand.Core.Register;
using TestStand.Lib.Modbus;

namespace TestStand.Core.Lectus;

public class LectusConfiguration
{
    public required ModbusConfiguration ModbusConfiguration { get; init; }
    public required FloatRegister OscilloscopeV { get; init; }
    public required BoolRegister OscilloscopeActive { get; init; }
}