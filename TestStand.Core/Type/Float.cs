using TestStand.Lib.Type.Interfaces;

namespace TestStand.Core.Type;

/// <summary>
/// Класс предоставляющий возможность Float переменной Modbus
/// </summary>
public class Float : IType
{
    private readonly float _value;

    public ushort[] Bytes => BitConverter.GetBytes(_value).ToUShortArray();

    public Float(ref float value)
    {
        _value = value;
    }
}

public static class BitConverterExtensions
{
    public static ushort[] ToUShortArray(this byte[] bytes)
    {
        if (bytes.Length % 2 != 0)
            throw new ArgumentException("Byte array length must be an even number.");

        var shorts = new ushort[bytes.Length / 2];

        for (int i = 0, j = 0; i < bytes.Length; i += 2, j++)
        {
            shorts[j] = BitConverter.ToUInt16(bytes, i);
        }

        Array.Reverse(shorts);
        return shorts;
    }
}