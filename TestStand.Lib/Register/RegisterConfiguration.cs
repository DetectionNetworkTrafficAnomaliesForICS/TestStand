namespace TestStand.Lib.Register;

/// <summary>
/// Регистр Modbus
/// </summary>
public class RegisterConfiguration
{
    /// <summary>
    /// Адресс регистра
    /// </summary>
    public required string Address { get; init; }

    /// <summary>
    /// Тип регистра 
    /// </summary>
    public required string Type { get; init; }
}