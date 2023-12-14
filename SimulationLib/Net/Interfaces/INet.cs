namespace PlcLib.Net.Interfaces;

/// <summary>
/// Сетевой интерфейс
/// </summary>
public interface INet
{
    /// <summary>
    /// IpV4 адресс
    /// </summary>
    string Address { get; }
    
    /// <summary>
    /// Порт
    /// </summary>
    ushort Port { get; }
}