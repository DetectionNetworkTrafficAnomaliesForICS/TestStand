using TestStand.Abstractions.Cycle.Interfaces;
using TestStand.Abstractions.Type.Interfaces;

namespace TestStand.Abstractions.Variable.Interfaces;

/// <summary>
/// Класс переменной Modbus
/// </summary>
public interface IVariable : ICycleUpdatable
{
    /// <summary>
    /// Значение переменной
    /// </summary>
    public IType Value { get; set; }
    public UpdateHandler UpdateFun { get; }

    void ICycleUpdatable.UpdateByCycle(ulong cycle)
    {
        UpdateFun(cycle);
    }
    
    delegate IType UpdateHandler(ulong cycle);
}