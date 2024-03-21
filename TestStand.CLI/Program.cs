using System.Net.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NModbusAsync;
using TestStand.Core.Converter;
using TestStand.Core.Cycle;
using TestStand.Core.Lectus;
using TestStand.Core.Modbus;
using TestStand.Core.Plc;
using TestStand.Core.Register;
using TestStand.Lib.Converter.Interfaces;
using TestStand.Lib.Device.Interfaces;
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
                services.Configure<LectusConfiguration>(
                    hostContext.Configuration.GetSection(nameof(LectusConfiguration)));
                services.Configure<WavePlcConfiguration>(
                    hostContext.Configuration.GetSection(nameof(WavePlcConfiguration)));
                services.Configure<CycleConfiguration>(
                    hostContext.Configuration.GetSection(nameof(CycleConfiguration)));
                services.AddHostedService<CycleService>();
                services.AddSingleton<IСonverterService, СonverterService>();
                services.AddSingleton<IConverter<float>, FloatСonverter>();
                services.AddSingleton<IConverter<bool>, BoolConverter>();
                services.AddSingleton<IModbusService, ModbusService>();
                services.AddSingleton<IModbusFactory, ModbusFactory>();
                services.AddTransient<TcpClient>();
                services.AddSingleton<WavePlc>();
                services.AddSingleton<IEmulationDevice>(serv => serv.GetRequiredService<WavePlc>());
                services.AddTransient<LectusClient>();
            });
    }
}