using TestStand.Lib.Register.Interfaces;

namespace TestStand.Lib.Register;

public class FloatRegister : IRegister<float>
{
    public required RegisterConfiguration Configuration { get; init; }
    
    public byte[] GetBytes(float value)
    {
        return BitConverter.GetBytes(value);
    }

    public float FromByte(byte[] bytes)
    {
        return BitConverter.ToSingle(bytes, 0);
    }
}

 