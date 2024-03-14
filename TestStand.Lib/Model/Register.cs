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
    public TypeRegister Type { get; }
    
    public Register(ushort address, TypeRegister typeRegister)
    {
        Address = address;
        Type = typeRegister;
    }

    public override string ToString()
    {
        return $"{Type}#{Address}";
    }

    public enum TypeRegister
     {
         Holding,
         Input,
         Coil
     }
}

