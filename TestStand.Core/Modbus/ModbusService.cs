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
                    var data = converter?.GetBytes(variable).ToUShortArray();
                    if (data?.Length > 1)
                    {
                        await master.WriteMultipleRegistersAsync(modbusClient.ServerConfiguration.Id, register.Address,
                            data);
                    }

                    if (data?.Length == 1)
                    {
                        await master.WriteSingleRegisterAsync(modbusClient.ServerConfiguration.Id, register.Address,
                            data[0]);
                    }
                }
                    break;
                case TypeRegister.Coil:
                {
                    var data = converter?.GetBytes(variable).ToBoolArray();

                    if (data?.Length > 1)
                    {
                        await master.WriteMultipleCoilsAsync(modbusClient.ServerConfiguration.Id, register.Address,
                            data);
                    }

                    if (data?.Length == 1)
                    {
                        await master.WriteSingleCoilAsync(modbusClient.ServerConfiguration.Id, register.Address,
                            data[0]);
                    }
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

    public async Task<(bool, T?)> TryRequestReadAsync<T>(IModbusClient modbusClient, IRegister<T> register)
    {
        var master = _modbusFactory.CreateTcpMaster(modbusClient.TcpClient);

        try
        {
            var converter = _converterService.GetConverter<T>();
            switch (register.Type)
            {
                case TypeRegister.Holding:
                {
                    var response = await master.ReadHoldingRegistersAsync(modbusClient.ServerConfiguration.Id,
                        register.Address,
                        (ushort)(converter.CountByte / 2));
                    var bytes = response.Reverse().SelectMany(BitConverter.GetBytes).ToArray();
                    var result = converter.FromByte(bytes);

                    return (true, result);
                }
                case TypeRegister.Coil:
                {
                    var response = await master.ReadCoilsAsync(modbusClient.ServerConfiguration.Id, register.Address,
                        converter.CountByte);
                    var bytes = response.Reverse().SelectMany(BitConverter.GetBytes).ToArray();
                    var result = converter.FromByte(bytes);

                    return (true, result);
                }
                case TypeRegister.Input:
                {
                    var response = await master.ReadInputRegistersAsync(modbusClient.ServerConfiguration.Id,
                        register.Address,
                        (ushort)(converter.CountByte / 2));
                    var bytes = response.Reverse().SelectMany(BitConverter.GetBytes).ToArray();
                    var result = converter.FromByte(bytes);

                    return (true, result);
                }
                case TypeRegister.DiscreteInput:
                {
                    var response = await master.ReadInputsAsync(modbusClient.ServerConfiguration.Id,
                        register.Address,
                         converter.CountByte);
                    var bytes = response.Reverse().SelectMany(BitConverter.GetBytes).ToArray();
                    var result = converter.FromByte(bytes);

                    return (true, result);
                }
                default:
                    return (false, default);
            }
        }
        catch (Exception ex)
        {
            return (false, default);
        }
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

    public static bool[] ToBoolArray(this byte[] bytes)
    {
        bool[] boolArray = new bool[bytes.Length];

        for (int i = 0; i < bytes.Length; i++)
        {
            boolArray[i] = bytes[i] == 0;
        }

        return boolArray;
    }
}