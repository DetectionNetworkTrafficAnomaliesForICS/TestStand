using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IConfiguration = TestStand.Lib.Configuration.Interfaces.IConfiguration;

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
                services.AddSingleton<IConfiguration, EmulationConfiguration>();
                services.AddSingleton<IPlc>(new WavePlc(10f, 12f));
                services.AddSingleton<IOpcClient>(new Lectus(new LocalHost(502)));
            });
    }
}