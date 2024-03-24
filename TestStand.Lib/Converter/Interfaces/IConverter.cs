namespace TestStand.Lib.Converter.Interfaces;

public interface IConverter<T>
{
    byte[] GetBytes(T value);
    T FromByte(byte[] bytes);
    ushort CountByte { get; }
}