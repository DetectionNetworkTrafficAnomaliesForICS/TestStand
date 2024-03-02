using TestStand.Lib.Model;

namespace TestStand.Lib.Plc.Interfaces;

/// <summary>
/// Абстракция программируемого логического контроллера 
/// </summary>
public interface IPlc
{
    
    /// <summary>
    /// Идентификационный номер
    /// </summary>
    byte Id { get; }
    
    /// <summary>
    /// Набор переменных
    /// </summary>
    IEnumerable<Node> Nodes { get; }


    /// <summary>
    /// Функция переводит PLC в следующее фиксированное состояние 
    /// </summary>
    /// <param name="t">Время в секундах</param>
    public void NextIteration(float t);
}