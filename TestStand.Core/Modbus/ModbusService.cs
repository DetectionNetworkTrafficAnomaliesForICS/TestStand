using NModbusAsync;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Model;
using TestStand.Lib.Type.Interfaces;

namespace TestStand.Core.Modbus;

public class ModbusService
{
    public async Task Send(IModbusClient modbusClient, Register register, IType variable)
    {
        var factory = new ModbusFactory();
        var master = factory.CreateTcpMaster(modbusClient.TcpClient);

        try
        {
            switch (register.Type)
            {
                case Register.TypeRegister.Holding:
                {
                    await master.WriteMultipleRegistersAsync(modbusClient.ServerConfiguration.Id, register.Address,
                        variable.Bytes);
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