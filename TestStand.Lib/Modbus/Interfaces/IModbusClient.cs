﻿using System.Net.Sockets;
using TestStand.Lib.Net;
using TestStand.Lib.Plc.Interfaces;

namespace TestStand.Lib.Modbus.Interfaces;

/// <summary>
/// Интерфейс для OPC серверов
/// </summary>
public interface IModbusClient
{
    ModbusConfiguration ServerConfiguration { get; }

    TcpClient TcpClient { get; }
    
    void Connect();
    void Disconnect();
}