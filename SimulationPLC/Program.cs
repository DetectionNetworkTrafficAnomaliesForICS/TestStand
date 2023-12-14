using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using NModbus;
using NModbusAsync;

class Program
{
    static async Task Main()
    {
        var ipAddress = "127.0.0.1"; // Replace with the IP address of your Modbus TCP server
        var port = 502; // Modbus TCP default port

        using (var tcpClient = new TcpClient(ipAddress, port))
        {
            var factory = new ModbusFactory();
            var master = factory.CreateTcpMaster(tcpClient);

            // Example: Write a float value to a single register
            float floatValue = 123.45f;
            ushort registerAddress = 0xC04; // Replace with your desired register address

            // Convert float to two 16-bit integers (words)
            ushort[] values = BitConverter.GetBytes(floatValue).ToUShortArray();

            try
            {
                await master.WriteMultipleRegistersAsync(1, registerAddress, values);
                Console.WriteLine($"Float value {floatValue} written to register {registerAddress}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

public static class BitConverterExtensions
{
    public static ushort[] ToUShortArray(this byte[] bytes)
    {
        if (bytes.Length % 2 != 0)
            throw new ArgumentException("Byte array length must be an even number.");

        ushort[] shorts = new ushort[bytes.Length / 2];

        for (int i = 0, j = 0; i < bytes.Length; i += 2, j++)
        {
            shorts[j] = BitConverter.ToUInt16(bytes, i);
        }
        
        Array.Reverse(shorts);
        return shorts;
    }
}