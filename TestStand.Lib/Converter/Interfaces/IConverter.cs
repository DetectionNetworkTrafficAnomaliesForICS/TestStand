namespace TestStand.Lib.Modbus.Interfaces;

public interface IConverter<T>
{
    byte[] GetBytes(T value);
    T FromByte(byte[] bytes);
}