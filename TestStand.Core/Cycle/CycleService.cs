using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TestStand.Lib.Device.Interfaces;

namespace TestStand.Core.Cycle;

public class CycleService : BackgroundService
{
    private readonly CycleConfiguration _cycleConfig;
    private readonly IEmulationDevice _device;
    
    private ulong _cycles;

    public CycleService(IEmulationDevice device, IOptions<CycleConfiguration> cycleConfig)
    {
        _device = device;
        _cycleConfig = cycleConfig.Value;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _device.Setup().GetAwaiter().GetResult();
        
        while (!stoppingToken.IsCancellationRequested)
        {
            Task.Delay((int)_cycleConfig.Duration);
            _cycles++;
            _device.UpdateByCycle(_cycles);
        }
        
        _device.Shutdown().GetAwaiter().GetResult();
        
        return Task.CompletedTask;
    }
}