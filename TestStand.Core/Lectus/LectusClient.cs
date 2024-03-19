using Microsoft.Extensions.Options;
using TestStand.Core.Lectus;
using TestStand.Lib.Net;
using TestStand.Lib.OpcClient.Interfaces;
using TestStand.Lib.Plc.Interfaces;
using static TestStand.Core.Modbus.ModbusClient;

namespace TestStand.Core.Opc;

public class LectusClient : IOpcClient
{
    private readonly IOptions<LectusConfiguration> _options;
    public NetConfiguration NetConfiguration => _options.Value.ModbusConfiguration.NetConfiguration;

    public LectusClient(IOptions<LectusConfiguration> options)
    {
        _options = options;
    }

    public void GetFrom(IPlc plc)
    {
        Send(this, plc).GetAwaiter().GetResult();
    }
}