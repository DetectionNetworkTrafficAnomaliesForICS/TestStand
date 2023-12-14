using Core.Net;
using Core.Opc;
using Core.Plc;

namespace ConsoleApp;

class Program
{
    private static readonly WavePlc Plc = new WavePlc(12f, 20f);
    private static readonly Lectus LectusClient = new Lectus(new LocalHost(502));

    static async Task Main()
    {
        Console.WriteLine("Start of the program.");
        
        await RunLoopAsync();

        Console.WriteLine("End of the program.");
    }

    static async Task RunLoopAsync()
    {
        var time = 0f;
        while (true)
        {
            Console.WriteLine($"Inside the loop{time}");

            // Pause for 5 seconds
            await Task.Delay(5000);
            time += 5f;
            Plc.NextIteration(time);
            LectusClient.GetFrom(Plc);
            // Optionally, add a condition to exit the loop
            // For example, break the loop after a certain number of iterations
            // if (someCondition)
            // {
            //    break;
            // }
        }
    }
}