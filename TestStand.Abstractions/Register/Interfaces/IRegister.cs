namespace TestStand.Abstractions.Register.Interfaces;

/// <summary>
/// Регистр Modbus
/// </summary>
public interface IRegister
{
    /// <summary>
    /// Адресс регистра
    /// </summary>
    public ushort Address { get; }
    
    /// <summary>
    /// Тип регистра 
    /// </summary>
    public Type TypeRegister { get; }
    
    public enum Type 
    {
        Holding,
        Input,
        Coil
    }
}
