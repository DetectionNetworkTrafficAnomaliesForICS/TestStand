using Microsoft.Extensions.Options;
using TestStand.Core.Lectus;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Plc.Interfaces;

namespace TestStand.Core.Plc;

/// <summary>
/// Класс эмулирующий работу датчика волны 
/// </summary>
/// <returns>The result of the custom operation.</returns>
public class WavePlc : IPlc
{
    private readonly WavePlcConfiguration _waveConfig;
    private readonly LectusClient _lectusClient;
    private readonly IModbusService _modbusService;

    public string Name => nameof(WavePlc);
    private float _current;

    public WavePlc(IOptions<WavePlcConfiguration> waveConfig, LectusClient lectusClient, IModbusService modbusService)
    {
        _waveConfig = waveConfig.Value;
        _lectusClient = lectusClient;
        _modbusService = modbusService;
    }

    public void UpdateByCycle(ulong cycle)
    {
        _current = _waveConfig.Amplitude * float.Sin(_waveConfig.AngularVelocity * cycle);
        _modbusService.TryRequestWriteAsync(_lectusClient, _lectusClient.Configuration.OscilloscopeV, _current).GetAwaiter()
            .GetResult();
    }

    public Task Setup()
    {
        _lectusClient.Connect();

        return Task.CompletedTask;
    }

    public Task Shutdown()
    {
        _lectusClient.Disconnect();
        
        return Task.CompletedTask;
    }

     
}