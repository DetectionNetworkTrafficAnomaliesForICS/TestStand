using PlcLib.Net.Interfaces;
using PlcLib.OpcClient.Interfaces;
using PlcLib.Plc.Interfaces;
using static Core.Modbus.ModbusClient;

namespace Core.Opc;

public class LectusClient : IOpcClient
{
    public INet NetInterface { get; }

    public LectusClient(INet netInterface)
    {
        NetInterface = netInterface;
    }

    public void GetFrom(IPlc plc)
    {
        Send(this, plc).GetAwaiter().GetResult();
    }
}