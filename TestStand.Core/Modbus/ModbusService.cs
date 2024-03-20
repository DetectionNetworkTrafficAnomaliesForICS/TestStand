using NModbusAsync;
using TestStand.Lib.Converter.Interfaces;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Register;
using TestStand.Lib.Register.Interfaces;


namespace TestStand.Core.Modbus;

public class ModbusService: IModbusService
{
    private readonly IСonverterService _converterService;

    public ModbusService(IСonverterService converterService)
    {
        _converterService = converterService;
    }

    public async Task<bool> TryRequestWriteAsync<T>(IModbusClient modbusClient, IRegister<T> register, T variable)
    {
        var factory = new ModbusFactory();
        var master = factory.CreateTcpMaster(modbusClient.TcpClient);

        try
        {
            switch (register.Type)
            {
                case TypeRegister.Holding:
                {
                    var converter = _converterService.GetConverter<T>();
                      await master.WriteMultipleRegistersAsync(modbusClient.ServerConfiguration.Id, register.Address,
                          converter?.GetBytes(variable).ToUShortArray());
                    
                }
                    break;
                default:
                    return false;
            }

            Console.WriteLine($"successfully sent {register} to {modbusClient}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }

        return true;
    }
}
public static class BitConverterExtensions
{
    public static ushort[] ToUShortArray(this byte[] bytes)
    {
        if (bytes.Length % 2 != 0)
            throw new ArgumentException("Byte array length must be an even number.");

        var shorts = new ushort[bytes.Length / 2];

        for (int i = 0, j = 0; i < bytes.Length; i += 2, j++)
        {
            shorts[j] = BitConverter.ToUInt16(bytes, i);
        }

        Array.Reverse(shorts);
        return shorts;
    }
}