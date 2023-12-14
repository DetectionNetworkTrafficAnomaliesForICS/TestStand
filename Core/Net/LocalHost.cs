using PlcLib.Net.Interfaces;

namespace Core.Net;

/// <summary>
/// Внутренний сетевой интерфейс хоста 
/// </summary>
public class LocalHost : INet
{

    public string Address => "127.0.0.1";

    public ushort Port { get; init; }
    
    public LocalHost(ushort port)
    {
        Port = port;
    }
}