using TestStand.Abstractions.Cycle.Interfaces;
using TestStand.Abstractions.Type.Interfaces;
using TestStand.Abstractions.Variable.Interfaces;

namespace TestStand.Lib.Variable;

public class Variable : IVariable
{
    public IType Value { get; set; }
    public IVariable.UpdateHandler UpdateFun { get; }
    
    public Variable(IType value, IVariable.UpdateHandler updateFun)
    {
        Value = value;
        UpdateFun = updateFun;
    }
}