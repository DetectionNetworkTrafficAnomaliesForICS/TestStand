using System.Net.Sockets;
using TestStand.Lib.Net;
using TestStand.Lib.Plc.Interfaces;

namespace TestStand.Lib.OpcClient.Interfaces;

/// <summary>
/// Интерфейс для OPC серверов
/// </summary>
public interface IOpcClient
{
    NetConfiguration NetConfiguration { get; }

    TcpClient TcpClient => new(NetConfiguration.Address, NetConfiguration.Port);
    void GetFrom(IPlc plc);
}