using TestStand.Lib.Net.Interfaces;

namespace TestStand.Core.Net;

/// <summary>
/// Внутренний сетевой интерфейс хоста 
/// </summary>
public class LocalHost : INet
{

    public string Address => "127.0.0.1";

    public ushort Port { get; }
    
    public LocalHost(ushort port)
    {
        Port = port;
    }
}