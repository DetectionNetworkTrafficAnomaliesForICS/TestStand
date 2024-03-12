namespace TestStand.Abstractions.Net.Interfaces;

public interface INetConfiguration
{
    string Address { get; }
    ushort Port { get; }
}