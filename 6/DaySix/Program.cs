using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();
sw.Start();
Console.WriteLine("Hello, World!");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IProcessRunner, ProcessRunner>()
        .AddSingleton<IInputService, InputService>()
        .AddSingleton<IFishProcessService, FishProcessService>()
    ).Build();
var runner = host.Services.GetService<IProcessRunner>();
await runner.Run(256);
sw.Stop();
Console.WriteLine("time" + sw.ElapsedMilliseconds.ToString());
Console.ReadLine();