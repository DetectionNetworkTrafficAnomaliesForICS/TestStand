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

            // Example: Reading holding registers
            ushort startAddress = 0xA01;
            ushort numberOfPoints = 1;

            try
            {
                await master.WriteSingleRegisterAsync(1, startAddress, 100);
                
                Console.WriteLine("Read Holding Registers:");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}