using System.Net.Sockets;
using PlcLib.Net.Interfaces;
using PlcLib.Plc.Interfaces;

namespace PlcLib.OpcClient.Interfaces;

/// <summary>
/// Интерфейс для OPC серверов
/// </summary>
public interface IOpcClient
{
    INet NetInterface { get; }

    TcpClient TcpClient => new(NetInterface.Address, NetInterface.Port);
    void GetFrom(IPlc plc);
}