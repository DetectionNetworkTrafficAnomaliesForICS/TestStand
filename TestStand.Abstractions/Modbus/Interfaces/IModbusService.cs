using TestStand.Abstractions.Register.Interfaces;
using TestStand.Abstractions.Variable.Interfaces;

namespace TestStand.Abstractions.Modbus.Interfaces;

public interface IModbusService
{
    public bool TryRequestReadRegister(IModbusClient client, IModbusServer server, IRegister register,
        in IVariable variable);

    public bool TryRequestWriteRegister(IModbusClient client, IModbusServer server, IRegister register,
        out IVariable variable);
}