using PlcLib.Model;
using PlcLib.Net.Interfaces;

namespace PlcLib.Plc.Interfaces;

public interface IPlc
{
    byte Id { get; }
    IEnumerable<Node> Nodes { get; }


    /// <summary>
    /// Функция переводит PLC в следующее фиксированное состояние 
    /// </summary>
    /// <param name="t">Время в секундах</param>
    public void NextIteration(float t);
}