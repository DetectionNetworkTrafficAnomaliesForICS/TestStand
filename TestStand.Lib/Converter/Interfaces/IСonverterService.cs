using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Register.Interfaces;

namespace TestStand.Lib.Converter.Interfaces;

public interface IСonverterService
{
    IConverter<T>? GetConverter<T>();
}