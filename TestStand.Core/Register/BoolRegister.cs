using TestStand.Lib.Register;
using TestStand.Lib.Register.Interfaces;

namespace TestStand.Core.Register;

public class BoolRegister: IRegister<bool>
{
    public required RegisterConfiguration Configuration { get; init; }
    
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
