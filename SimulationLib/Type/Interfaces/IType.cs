namespace PlcLib.Type.Interfaces;

/// <summary>
/// Интерфейс для реализации типов Modbus
/// </summary>
public interface IType
{
    /// <summary>
    /// Получение байт типа значения 
    /// </summary>
    /// <returns>массив байтов</returns>
    public ushort[] Bytes { get; }
}
