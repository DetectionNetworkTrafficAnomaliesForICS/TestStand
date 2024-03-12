namespace TestStand.Abstractions.Cycle.Interfaces;

public interface ICycleHandlerService
{
    public void Add(ICycleUpdatable cycleUpdatable);
    public void Remove(ICycleUpdatable cycleUpdatable);
}
 