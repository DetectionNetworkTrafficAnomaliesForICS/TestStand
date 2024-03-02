using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestStand.Core.Net;
using TestStand.Core.Opc;
using TestStand.Core.Plc;
using TestStand.Lib.OpcClient.Interfaces;
using TestStand.Lib.Plc.Interfaces;
using IConfiguration = TestStand.Lib.Model.IConfiguration;

namespace TestStand.CLI;

internal static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<CycleService>();
                services.AddSingleton<IConfiguration, Configuration>();
                services.AddSingleton<IPlc>(new WavePlc(10f, 12f));
                services.AddSingleton<IOpcClient>(new LectusClient(new LocalHost(502)));
            });
    }
}