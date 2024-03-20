﻿using Microsoft.Extensions.Options;
using TestStand.Lib.Modbus;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Net;
using TestStand.Lib.Plc.Interfaces;
using static TestStand.Core.Modbus.ModbusClient;

namespace TestStand.Core.Lectus;

public class LectusClient : IModbusClient
{
    private readonly IOptions<LectusConfiguration> _options;
    public ModbusConfiguration ServerConfiguration => _options.Value.ModbusConfiguration;
   
    public LectusClient(IOptions<LectusConfiguration> options)
    {
        _options = options;
    }
    
    public void GetFrom(IPlc plc)
    {
        Send(this, plc).GetAwaiter().GetResult();
    }
}