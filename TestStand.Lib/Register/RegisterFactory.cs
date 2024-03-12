using TestStand.Abstractions.Register.Interfaces;

namespace TestStand.Lib.Register;

public class RegisterFactory : IRegisterFactory
{
    public IRegister CreateInputRegister(ushort address)
    {
        return new Register(IRegister.Type.Input, address);
    }
    public IRegister CreateCoilRegister(ushort address)
    {
        return new Register(IRegister.Type.Coil, address);
    }
    public IRegister CreateHoldingRegister(ushort address)
    {
        return new Register(IRegister.Type.Holding, address);
    }
}