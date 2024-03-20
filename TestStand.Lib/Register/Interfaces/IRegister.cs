

namespace TestStand.Lib.Register.Interfaces;

public interface IRegister<T>
{
    RegisterConfiguration Configuration { get; init; }

    byte[] GetBytes(T value);
    T FromByte(byte[] bytes);
    
    /// <summary>
    /// Адресс регистра
    /// </summary>
    ushort Address => Convert.ToUInt16(Configuration.Address,16);

    /// <summary>
    /// Тип регистра 
    /// </summary>
    TypeRegister Type =>
        Configuration.Type switch
        {
            "Holding" => TypeRegister.Holding,
            "Coil" => TypeRegister.Coil,
            "Input" => TypeRegister.Input,
            _ => Type
        };
    
    public enum TypeRegister
    {
        Holding,
        Input,
        Coil
    }
}