namespace TestStand.Lib.Model;

/// <summary>
/// Регистр Modbus
/// </summary>
public class Register
{
    /// <summary>
    /// Адресс регистра
    /// </summary>
    public ushort Address { get; }
    
    /// <summary>
    /// Тип регистра 
    /// </summary>
    public TypeRegister TypeRegister { get; }
    
    public Register(ushort address, TypeRegister typeRegister)
    {
        Address = address;
        TypeRegister = typeRegister;
    }
}

public enum TypeRegister
{
    Holding,
    Input,
    Coil
}