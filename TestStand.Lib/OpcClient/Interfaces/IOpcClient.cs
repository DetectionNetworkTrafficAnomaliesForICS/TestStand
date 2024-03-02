using System.Net.Sockets;
using TestStand.Lib.Net.Interfaces;
using TestStand.Lib.Plc.Interfaces;

namespace TestStand.Lib.OpcClient.Interfaces;

/// <summary>
/// Интерфейс для OPC серверов
/// </summary>
public interface IOpcClient
{
    INet NetInterface { get; }

    TcpClient TcpClient => new(NetInterface.Address, NetInterface.Port);
    void GetFrom(IPlc plc);
}