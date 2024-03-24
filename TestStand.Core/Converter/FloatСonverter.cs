using TestStand.Lib.Converter.Interfaces;

namespace TestStand.Core.Converter;

public class FloatСonverter: IConverter<float>
{
    public ushort CountByte => 4;
    
    public byte[] GetBytes(float value)
    {
        return BitConverter.GetBytes(value);
    }

    public float FromByte(byte[] bytes)
    {
        return BitConverter.ToSingle(bytes, 0);
    }
}