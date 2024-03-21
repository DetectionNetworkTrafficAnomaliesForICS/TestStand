using TestStand.Lib.Modbus.Interfaces;

namespace TestStand.Core.Converter;

public class BoolConverter: IConverter<bool>
{
    public byte[] GetBytes(bool value)
    {
        return BitConverter.GetBytes(value);
    }

    public bool FromByte(byte[] bytes)
    {
        return BitConverter.ToBoolean(bytes, 0);
    }
}