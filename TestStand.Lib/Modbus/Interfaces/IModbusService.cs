using TestStand.Lib.Register.Interfaces;

namespace TestStand.Lib.Modbus.Interfaces;

public interface IModbusService
{
    Task<bool> TryRequestWriteAsync<T>(IModbusClient modbusClient, IRegister<T> register, T variable);
    //Task<(bool,T)> TryRequestReadAsync<T>(IModbusClient modbusClient, IRegister<T> register);
}