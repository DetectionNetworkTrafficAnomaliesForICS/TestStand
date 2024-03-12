using TestStand.Abstractions.Cycle.Interfaces;
using TestStand.Abstractions.Variable.Interfaces;

namespace TestStand.Abstractions.Register.Interfaces;

public interface ISetRegisters
{
    public bool TryReadRegister(IRegister register, out IVariable? variable);
    public bool TryWriteRegister(IRegister register, in IVariable variable);
}