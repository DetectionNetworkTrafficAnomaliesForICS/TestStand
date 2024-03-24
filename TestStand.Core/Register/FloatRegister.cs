using TestStand.Lib.Register;
using TestStand.Lib.Register.Interfaces;

namespace TestStand.Core.Register;

public class FloatRegister : IRegister<float>
{
    public required RegisterConfiguration Configuration { get; init; }
   
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

 