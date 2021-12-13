using System.Data.SqlTypes;

var sw = new Stopwatch();
Console.WriteLine("Day 13");
using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IProcessRunner, ProcessRunner>()
            .AddSingleton<IFoldService, FoldService>()
            .AddSingleton<IPrintService, PrintService>()
            .AddSingleton<IInputService, InputService>()
    ).Build();
var runner = host.Services.GetService<IProcessRunner>();
sw.Start();
await runner?.Part1()!;
sw.Stop();
Console.WriteLine($"Part 1 : Running time is {sw.ElapsedMilliseconds}ms");
sw.Reset();
sw.Start();
await runner?.Part2()!;
sw.Stop();
Console.WriteLine($"Part 2 Running time is {sw.ElapsedMilliseconds}ms");