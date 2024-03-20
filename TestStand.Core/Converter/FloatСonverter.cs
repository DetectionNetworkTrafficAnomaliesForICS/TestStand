using TestStand.Lib.Modbus.Interfaces;

namespace TestStand.Core.Converter;

public class FloatСonverter: IConverter<float>
{
    public byte[] GetBytes(float value)
    {
        return BitConverter.GetBytes(value);
    }

    public float FromByte(byte[] bytes)
    {
        return BitConverter.ToSingle(bytes, 0);
    }
}