using PlcLib.Type.Interfaces;

namespace PlcLib.Model;

/// <summary>
/// Класс переменной Modbus
/// </summary>
public class Node
{
    /// <summary>
    /// Регистр переменной 
    /// </summary>
    public Register Register { get; }

    /// <summary>
    /// Значение переменной
    /// </summary>
    public IType Value { get; init; }

    public Node(Register register, IType value)
    {
        Register = register;
        Value = value;
    }
}