using System.Timers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TestStand.Lib.Plc.Interfaces;
using Timer = System.Timers.Timer;

namespace TestStand.Core.Cycle;

public class CycleService : BackgroundService
{
    private readonly IPlc _plc;
    private readonly CycleConfiguration _cycleConfig;

    private long _cycles;

    public CycleService(IPlc plc, IOptions<CycleConfiguration> cycleConfig)
    {
        _plc = plc;
        _cycleConfig = cycleConfig.Value;
   }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new Timer(_cycleConfig.Duration);

        timer.Elapsed += OnTimedEvent;
        timer.Start();
        Console.ReadLine();
        return Task.CompletedTask;
    }

    private void OnTimedEvent(object? source, ElapsedEventArgs e)
    {
        _cycles++;
        _plc.NextIteration(_cycles);
        //_modbus.GetFrom(_plc);
    }
}