using System.Timers;
using Microsoft.Extensions.Hosting;
using TestStand.Lib;
using TestStand.Lib.Model;
using TestStand.Lib.OpcClient.Interfaces;
using TestStand.Lib.Plc.Interfaces;
using Timer = System.Timers.Timer;

namespace TestStand.CLI;

public class CycleService : BackgroundService
{
    private readonly IConfiguration _config;
    private readonly IPlc _plc;
    private readonly IOpcClient _opc;

    private long _cycles;

    public CycleService(IPlc plc, IOpcClient opc, IConfiguration config)
    {
        _plc = plc;
        _opc = opc;
        _config = config;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new Timer(_config.DurationCycle);

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