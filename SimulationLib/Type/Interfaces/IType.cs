using PlcLib.Model;

namespace PlcLib.Type.Interfaces;

/// <summary>
/// Интерфейс для реализации типов Modbus
/// </summary>
public interface IType
{
    /// <summary>
    /// Получение hex значения 
    /// </summary>
    /// <returns>The result of the custom operation.</returns>
    Hex Hex { get; set; }
}
