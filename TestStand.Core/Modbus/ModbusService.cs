using NModbusAsync;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Model;
using TestStand.Lib.Plc.Interfaces;

namespace TestStand.Core.Modbus;

public class ModbusService 
{
    public async Task Send(IModbusClient modbusClient, IPlc plc)
    {
        var factory = new ModbusFactory();
        var master = factory.CreateTcpMaster(modbusClient.TcpClient);

        var nodes = plc.Nodes;
        
        try
        {
            foreach (var node in nodes)
            {
                switch (node.Register.Type)
                {
                    case Register.TypeRegister.Holding:
                    {
                        await master.WriteMultipleRegistersAsync(plc.Id, node.Register.Address, node.Value.Bytes);
                    }
                        break;
                    case Register.TypeRegister.Input:
                        break;
                    case Register.TypeRegister.Coil:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                } 
                
                Console.WriteLine($"{plc} successfully sent the node {node}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}