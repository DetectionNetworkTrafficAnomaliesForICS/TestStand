using TestStand.Abstractions.Register.Interfaces;

namespace TestStand.Lib.Register;

public class Register : IRegister
{
    public ushort Address { get; }
    public IRegister.Type TypeRegister { get; }
    
    public Register(IRegister.Type typeRegister, ushort address)
    {
        Address = address;
        TypeRegister = typeRegister;
    }
}