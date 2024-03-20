using System.Net.Sockets;
using Microsoft.Extensions.Options;
using TestStand.Lib.Modbus;
using TestStand.Lib.Modbus.Interfaces;

namespace TestStand.Core.Lectus;

public class LectusClient : IModbusClient
{
    public readonly LectusConfiguration Configuration;
    public ModbusConfiguration ServerConfiguration { get; init; }
    public TcpClient TcpClient { get; }

    public LectusClient(IOptions<LectusConfiguration> options, TcpClient tcpClient)
    {
        TcpClient = tcpClient;
        Configuration = options.Value;
        ServerConfiguration = options.Value.ModbusConfiguration;
    }
    
    public void Connect()
    {
        var netConfig = Configuration.ModbusConfiguration.NetConfiguration;
        TcpClient.Connect(netConfig.Address, netConfig.Port);
    }

    public void Disconnect()
    {
        TcpClient.Close();
    }
}