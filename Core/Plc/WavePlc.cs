using Core.Type;
using PlcLib.Model;
using PlcLib.Plc.Interfaces;

namespace Core.Plc;

/// <summary>
/// Класс эмулирующий работу датчика волны 
/// </summary>
/// <returns>The result of the custom operation.</returns>
public class WavePlc : IPlc
{
    private readonly float _w;
    private readonly float _a;

    private float _current = 0f;
    private readonly Register _register = new(0xC04, TypeRegister.Holding);
    

    public byte Id => 1;
    public IEnumerable<Node> Nodes => new List<Node>{new(_register, new Float(ref _current))};


    /// <summary>
    /// Инициализация PLC <see cref="WavePlc"/> class.
    /// </summary>
    /// <param name="a">Амплитуда волны</param>
    /// <param name="w">Угловая скорость волны</param>
    public WavePlc(float w, float a)
    {
        _w = w;
        _a = a;
    }

    public void NextIteration(float t)
    {
        _current = _a * float.Sin(_w * t);
    }
}