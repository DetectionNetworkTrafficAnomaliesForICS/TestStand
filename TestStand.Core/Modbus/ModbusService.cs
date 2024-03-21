using NModbusAsync;
using TestStand.Lib.Converter.Interfaces;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Register;
using TestStand.Lib.Register.Interfaces;


namespace TestStand.Core.Modbus;

public class ModbusService : IModbusService
{
    private readonly IСonverterService _converterService;
    private readonly IModbusFactory _modbusFactory;

    public ModbusService(IСonverterService converterService, IModbusFactory modbusFactory)
    {
        _converterService = converterService;
        _modbusFactory = modbusFactory;
    }

    public async Task<bool> TryRequestWriteAsync<T>(IModbusClient modbusClient, IRegister<T> register, T variable)
    {
        var master = _modbusFactory.CreateTcpMaster(modbusClient.TcpClient);

        try
        {
            var converter = _converterService.GetConverter<T>();
            switch (register.Type)
            {
                case TypeRegister.Holding:
                {
                    
                    await master.WriteMultipleRegistersAsync(modbusClient.ServerConfiguration.Id, register.Address,
                        converter?.GetBytes(variable).ToUShortArray());
                }
                    break;
                case TypeRegister.Coil:
                {
                    await master.WriteSingleCoilAsync(modbusClient.ServerConfiguration.Id, register.Address,
                        (bool)converter?.GetBytes(variable).ToBool());
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
    public static bool ToBool(this byte[] bytes)
    {
        return bytes[0] != 0;
    }
}