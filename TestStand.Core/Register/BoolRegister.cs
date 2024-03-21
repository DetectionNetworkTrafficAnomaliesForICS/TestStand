using TestStand.Lib.Register;
using TestStand.Lib.Register.Interfaces;

namespace TestStand.Core.Register;

public class BoolRegister: IRegister<bool>
{
    public required RegisterConfiguration Configuration { get; init; }
}
