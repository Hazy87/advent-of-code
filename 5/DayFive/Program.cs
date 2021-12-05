// See https://aka.ms/new-console-template for more information
global using DayFive.Interfaces;
global using DayFive.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();
sw.Start();
Console.WriteLine("Hello, World!");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IProcessRunner, ProcessRunner>()
        .AddTransient<IInputService, InputService>()
        .AddTransient<ICoordinateService, CoordinateService>()
        .AddTransient<IGridMarkerService, GridMarkerService>()
        ).Build();
var runner = host.Services.GetService<IProcessRunner>();
await runner.Run();
sw.Stop();
Console.WriteLine("time" + sw.ElapsedMilliseconds.ToString());

