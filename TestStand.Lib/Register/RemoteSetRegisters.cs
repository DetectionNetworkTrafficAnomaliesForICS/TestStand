using TestStand.Abstractions.Cycle.Interfaces;
using TestStand.Abstractions.Net.Interfaces;
using TestStand.Abstractions.Register.Interfaces;
using TestStand.Abstractions.Variable.Interfaces;

namespace TestStand.Lib.Register;

public class RemoteSetRegisters: ISetRegisters
{
    public ICycleHandlerService HandlerService { get; }
    public INetDevice NetDevice { get; }
    
    public bool TryReadRegister(IRegister register, out IVariable? variable)
    {
        throw new NotImplementedException();
    }

    public bool TryWriteRegister(IRegister register, in IVariable variable)
    {
        throw new NotImplementedException();
    }
}