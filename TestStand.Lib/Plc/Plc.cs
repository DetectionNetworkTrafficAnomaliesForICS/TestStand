using TestStand.Abstractions.Cycle.Interfaces;
using TestStand.Abstractions.Plc.Interfaces;
using TestStand.Abstractions.Register.Interfaces;
using TestStand.Lib.Register;

namespace TestStand.Lib.Plc;

public class Plc : IPlc
{
    public Plc(LocalSetRegisters registers, ICycleHandlerService handlerService)
    {
        Registers = registers;
        HandlerService = handlerService;
    }

    public ulong Id => 1;
    public string Name => "Plc";
    
    public ISetRegisters Registers { get; }
    public ICycleHandlerService HandlerService { get; }


    public void UpdateByCycle(ulong cycle)
    {
        throw new NotImplementedException();
    }

    public Task Setup()
    {
        throw new NotImplementedException();
    }

    public Task Shutdown()
    {
        throw new NotImplementedException();
    }
}