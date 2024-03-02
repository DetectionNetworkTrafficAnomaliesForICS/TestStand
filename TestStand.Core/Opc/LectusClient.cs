using TestStand.Lib.Net.Interfaces;
using TestStand.Lib.OpcClient.Interfaces;
using TestStand.Lib.Plc.Interfaces;
using static TestStand.Core.Modbus.ModbusClient;

namespace TestStand.Core.Opc;

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