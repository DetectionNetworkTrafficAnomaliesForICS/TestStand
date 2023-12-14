using System.Net.Sockets;
using NModbusAsync;

class Program
{
    
    // Устанавливаем флаг, который будет использоваться для определения, когда завершить программу
    private static bool ShouldExit = false;
    private static string  ipAddress = "127.0.0.1"; // Replace with the IP address of your Modbus TCP server
    private static int port = 502; // Modbus TCP default port
    private static int intervalInSeconds = 5;
    
    static async Task Main()
    {
       

        // Создайте таймер с указанным интервалом и обработчиком события
        Timer timer = new Timer(PrintMessage, null, 0, intervalInSeconds * 1000);


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
    
    static void PrintMessage(object? state)
    {
        // Здесь вы можете вставить свой код для вывода сообщения
        Console.WriteLine($"Текущее время: {DateTime.Now}");
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