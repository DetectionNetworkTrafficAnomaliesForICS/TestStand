using TestStand.Abstractions.Register.Interfaces;
using TestStand.Abstractions.Variable.Interfaces;

namespace TestStand.Abstractions.Modbus.Interfaces;

public interface IModbusClient: IModbusConfiguration
{
    public bool TryRequestReadRegister(IModbusServer server, IRegister register,
        in IVariable variable);

    public bool TryRequestWriteRegister(IModbusServer server, IRegister register,
        out IVariable variable);
}