using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestStand.Core.Cycle;
using TestStand.Core.Lectus;
using TestStand.Core.Modbus;
using TestStand.Core.Plc;
using TestStand.Lib.Modbus.Interfaces;
using TestStand.Lib.Plc.Interfaces;

namespace TestStand.CLI;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Запуск программы \"Тестовый стенд\" Котова Родиона ФИТ НГУ");
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.Configure<LectusConfiguration>(hostContext.Configuration.GetSection(nameof(LectusConfiguration)));
                services.Configure<WavePlcConfiguration>(hostContext.Configuration.GetSection(nameof(WavePlcConfiguration)));
                services.Configure<CycleConfiguration>(hostContext.Configuration.GetSection(nameof(CycleConfiguration)));
                services.AddHostedService<CycleService>();
                services.AddSingleton<IModbusService,ModbusService>();
                services.AddSingleton<IPlc, WavePlc>();
                services.AddSingleton<LectusClient>();
            });
    }
}