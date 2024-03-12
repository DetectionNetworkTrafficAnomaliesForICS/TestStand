namespace TestStand.Abstractions.Register.Interfaces;

public interface IRegisterFactory
{
    public IRegister CreateInputRegister(ushort address);
    public IRegister CreateCoilRegister(ushort address);
    public IRegister CreateHoldingRegister(ushort address);
}