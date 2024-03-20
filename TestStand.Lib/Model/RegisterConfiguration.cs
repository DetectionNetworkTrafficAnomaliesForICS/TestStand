namespace TestStand.Lib.Model;

/// <summary>
/// Регистр Modbus
/// </summary>
public class RegisterConfiguration
{
    /// <summary>
    /// Адресс регистра
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Тип регистра 
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Тип Значения 
    /// </summary>
    public string Value { get; set; }
    
    public RegisterConfiguration(string address, string type, string value)
    {
        Address = address;
        Type = type;
        Value = value;
    }
    // public Register(string address, string type)
    // {
    //     Address = Convert.ToUInt16(address,16);
    //     Type = type switch
    //     {
    //         "Holding" => TypeRegister.Holding,
    //         "Coil" => TypeRegister.Coil,
    //         "Input" => TypeRegister.Input,
    //         _ => Type
    //     };
    // }

    public override string ToString()
    {
        return $"{Type}#{Address}";
    }

    // public enum TypeRegister
    // {
    //     Holding,
    //     Input,
    //     Coil
    // }
}