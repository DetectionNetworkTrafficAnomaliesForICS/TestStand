using NModbusAsync;
using TestStand.Lib.Modbus.Interfaces;

using TestStand.Lib.Register.Interfaces;


namespace TestStand.Core.Modbus;

public class ModbusService
{
    public async Task Send<T>(IModbusClient modbusClient, IRegister<T> register, T variable)
    {
        var factory = new ModbusFactory();
        var master = factory.CreateTcpMaster(modbusClient.TcpClient);

        try
        {
            switch (register.Type)
            {
                case  IRegister<T>.TypeRegister.Holding:
                {
                    await master.WriteMultipleRegistersAsync(modbusClient.ServerConfiguration.Id, register.Address,
                         register.GetBytes(variable).ToUShortArray());
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine($"successfully sent {register} to {modbusClient}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
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
}