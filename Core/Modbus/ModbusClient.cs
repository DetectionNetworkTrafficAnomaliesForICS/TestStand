using NModbusAsync;
using PlcLib.Model;
using PlcLib.OpcClient.Interfaces;
using PlcLib.Plc.Interfaces;

namespace Core.Modbus;

public static class ModbusClient 
{
    public static async Task Send(IOpcClient opcClient, IPlc plc)
    {
        var factory = new ModbusFactory();
        var master = factory.CreateTcpMaster(opcClient.TcpClient);

        var nodes = plc.Nodes;
        
        try
        {
            foreach (var node in nodes)
            {
                switch (node.Register.TypeRegister)
                {
                    case TypeRegister.Holding:
                    {
                        await master.WriteMultipleRegistersAsync(plc.Id, node.Register.Address, node.Value.Hex.Bytes);
                    }
                        break;
                } 
                
                Console.WriteLine($"Send success from {plc} data: {node.Register}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}