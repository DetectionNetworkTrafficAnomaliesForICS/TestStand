using PlcLib.Net.Interfaces;
using PlcLib.OpcClient.Interfaces;
using PlcLib.Plc.Interfaces;
using static Core.Modbus.ModbusClient;

namespace Core.Opc;

public class Lectus : IOpcClient
{
    public INet NetInterface { get; init; }

    public Lectus(INet netInterface)
    {
        NetInterface = netInterface;
    }

    public void GetFrom(IPlc plc)
    {
        Send(this, plc).GetAwaiter().GetResult();
    }
}