namespace TestStand.Lib.Model;

public class Register
{
    public required RegisterConfiguration Configuration { get; init; }
    
    /// <summary>
    /// Адресс регистра
    /// </summary>
    public ushort Address => Convert.ToUInt16(Configuration.Address,16);

    /// <summary>
    /// Тип регистра 
    /// </summary>
    public TypeRegister Type =>
        Configuration.Type switch
        {
            "Holding" => TypeRegister.Holding,
            "Coil" => TypeRegister.Coil,
            "Input" => TypeRegister.Input,
            _ => Type
        };

    // public Register(RegisterConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }
    
    public enum TypeRegister
    {
        Holding,
        Input,
        Coil
    }
}