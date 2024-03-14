using Microsoft.Extensions.Options;
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
    private readonly IOptions<WavePlcConfiguration> _waveConfig;

    private float _current;
    private readonly Register _register = new(0xC04, TypeRegister.Holding);
    
    public byte Id => 1;
    public IEnumerable<Node> Nodes => new List<Node>{new(_register, new Float(ref _current))};
    
    public WavePlc(IOptions<WavePlcConfiguration> waveConfig)
    {
        _waveConfig = waveConfig;
    }

    public void NextIteration(float t)
    {
        _current = _waveConfig.Value.Amplitude * float.Sin(_waveConfig.Value.AngularVelocity * t);
    }
}