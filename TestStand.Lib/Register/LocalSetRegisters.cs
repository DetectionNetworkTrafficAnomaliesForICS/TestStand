using TestStand.Abstractions.Cycle.Interfaces;
using TestStand.Abstractions.Register.Interfaces;
using TestStand.Abstractions.Variable.Interfaces;

namespace TestStand.Lib.Register;

public class LocalSetRegisters: ISetRegisters
{
    public ICycleHandlerService HandlerService { get; }
    private IDictionary<IRegister, IVariable> Registers { get; }


    public LocalSetRegisters(ICycleHandlerService handlerService, IDictionary<IRegister, IVariable> registers)
    {
        HandlerService = handlerService;
        Registers = registers;
    }
    
    public bool TryReadRegister(IRegister register, out IVariable? variable)
    {
        if (Registers.TryGetValue(register, out var value))
        {
            variable = value;
            return true;
        }

        variable = null;
        return false;
    }

    public bool TryWriteRegister(IRegister register, in IVariable variable)
    {
        Registers[register] = variable;
        return true;
    }
}