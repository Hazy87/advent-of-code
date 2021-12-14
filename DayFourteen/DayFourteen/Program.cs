var sw = new Stopwatch();
Console.WriteLine("Hello, World!");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IProcessRunner, ProcessRunner>()
            .AddSingleton<IInputService, InputService>()
            .AddSingleton<IPolimerInsertionService, PolimerInsertionService>()
    ).Build();
var runner = host.Services.GetService<IProcessRunner>();

sw.Start();
await runner.Run();
sw.Stop();
Console.WriteLine("time" + sw.ElapsedMilliseconds.ToString());
Console.ReadLine();