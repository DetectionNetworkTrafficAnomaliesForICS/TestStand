using Microsoft.Extensions.Options;
using TestStand.Core.Lectus;
using TestStand.Core.Modbus;
using TestStand.Core.Type;
using TestStand.Lib.Model;
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
    private readonly ModbusService _modbusService;

    private float _current;
    private readonly Register _register = new(0xC04, Register.TypeRegister.Holding);
    
    public byte Id => 1;
    public IEnumerable<Node> Nodes => new List<Node>{new(_register, new Float(ref _current))};
    
    public WavePlc(IOptions<WavePlcConfiguration> waveConfig, LectusClient lectusClient, ModbusService modbusService)
    {
        _waveConfig = waveConfig.Value;
        _lectusClient = lectusClient;
        _modbusService = modbusService;
    }

    public void NextIteration(float t)
    {
        _current = _waveConfig.Amplitude * float.Sin(_waveConfig.AngularVelocity * t);
        _modbusService.Send(_lectusClient, this).GetAwaiter().GetResult();
    }

    public override string ToString()
    {
        return $"{nameof(WavePlc)}#{Id}";
    }
}