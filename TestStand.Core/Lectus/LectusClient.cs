using Microsoft.Extensions.Options;
using TestStand.Lib.Modbus;
using TestStand.Lib.Modbus.Interfaces;

namespace TestStand.Core.Lectus;

public class LectusClient : IModbusClient
{
    public readonly LectusConfiguration Configuration;
    public ModbusConfiguration ServerConfiguration => Configuration.ModbusConfiguration;
   
    public LectusClient(IOptions<LectusConfiguration> options)
    {   
        Configuration = options.Value;
    }
}