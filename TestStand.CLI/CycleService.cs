using System.Timers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TestStand.Abstractions.Opc.Interfaces;
using TestStand.Abstractions.Plc.Interfaces.IPlc.Interfaces;
using Timer = System.Timers.Timer;

namespace TestStand.CLI;

public class CycleService : BackgroundService
{
    private readonly IConfiguration _config;
    private readonly IPlc _plc;
    private readonly IOpc _opc;

    private long _cycles;

    public CycleService(IPlc plc, IOpc opc, Abstractions.Configuration.Interfaces.IEmulationConfiguration config)
    {
        _plc = plc;
        _opc = opc;
        _config = config 
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new Timer(_config.);

        timer.Elapsed += OnTimedEvent;
        timer.Start();
        Console.ReadLine();
        return Task.CompletedTask;
    }

    private void OnTimedEvent(object? source, ElapsedEventArgs e)
    {
        _cycles++;
        _plc.NextIteration(_cycles);
        _opc.GetFrom(_plc);
    }
}