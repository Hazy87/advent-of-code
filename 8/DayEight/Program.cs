global using DayEight.Interfaces;
global using DayEight.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();
Console.WriteLine("Hello, World!");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IProcessRunner, ProcessRunner>()
            .AddSingleton<IDecodeService, DecodeService>()
        .AddSingleton<IInputService, InputService>()
        .AddSingleton<INumberFindingService, NumberFindingService>()
    ).Build();
var runner = host.Services.GetService<IProcessRunner>();

sw.Start();

await runner.Run();
sw.Stop();
Console.WriteLine("time" + sw.ElapsedMilliseconds.ToString());
Console.ReadLine();