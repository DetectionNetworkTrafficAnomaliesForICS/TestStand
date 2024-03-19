using TestStand.Lib.Net;

namespace TestStand.Lib.Modbus;

public class ModbusConfiguration
{
    public byte Id { get; set; }
    public required NetConfiguration NetConfiguration { get; set; }
}