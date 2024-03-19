namespace TestStand.Lib.Net;

/// <summary>
/// Сетевой интерфейс
/// </summary>
public class NetConfiguration
{
    /// <summary>
    /// IpV4 адресс
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Порт
    /// </summary>
    public ushort Port { get; set; }
}