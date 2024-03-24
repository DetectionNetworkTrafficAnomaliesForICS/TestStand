using TestStand.Lib.Converter.Interfaces;

namespace TestStand.Core.Converter;

public class BoolConverter: IConverter<bool>
{
    public ushort CountByte => 1;

    public byte[] GetBytes(bool value)
    {
        return BitConverter.GetBytes(value);
    }

    public bool FromByte(byte[] bytes)
    {
        return BitConverter.ToBoolean(bytes, 0);
    }
}