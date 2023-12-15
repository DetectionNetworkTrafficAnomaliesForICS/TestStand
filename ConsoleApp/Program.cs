using Core.Net;
using Core.Opc;
using Core.Plc;
using PlcLib.OpcClient.Interfaces;
using PlcLib.Plc.Interfaces;

namespace ConsoleApp;

abstract class Program
{
    private static readonly CancellationTokenSource cts = new CancellationTokenSource();

    private static async Task Main()
    {
        
        float angularVelocity, amplitude, repeatTime;

        Console.WriteLine("Запуск программы \"Тестовый стенд\" Котова Родиона ФИТ НГУ");

        // Считывание angularVelocity из консоли
        do
        {
            Console.Write("Введите угловую скорость (angularVelocity): ");
        } while (!float.TryParse(Console.ReadLine(), out angularVelocity) || angularVelocity == 0);

        // Считывание amplitude из консоли
        do
        {
            Console.Write("Введите амплитуду (amplitude): ");
        } while (!float.TryParse(Console.ReadLine(), out amplitude) || amplitude == 0);

        // Считывание repeatTime из консоли
        do
        {
            Console.Write("Введите время повторения (repeatTime): ");
        } while (!float.TryParse(Console.ReadLine(), out repeatTime) || repeatTime == 0);

        var plc = new WavePlc(angularVelocity, amplitude);
        var lectusClient = new LectusClient(new LocalHost(502));

        
        
        Console.WriteLine("Для остановки программы нажмите Enter");

        // Запуск асинхронного цикла
        var loopTask = RunLoopAsync(repeatTime, plc, lectusClient);

        // Ожидание нажатия Enter для завершения программы
        Console.ReadLine();

        // При нажатии Enter, отменяем выполнение цикла
        cts.Cancel();

        // Ожидание завершения асинхронного цикла
        loopTask.Wait();
        
        await RunLoopAsync(repeatTime, plc, lectusClient);
    }

    private static async Task RunLoopAsync(float repeatTime, IPlc plc, IOpcClient opcClient)
    {
        var time = 0f;
        while (!cts.Token.IsCancellationRequested)
        {
            await Task.Delay((int)(repeatTime * 1000f), cts.Token);
            
            if (cts.Token.IsCancellationRequested)
            {
                break;
            }

            time += repeatTime;
            plc.NextIteration(time);
            opcClient.GetFrom(plc);
        }
    }
}