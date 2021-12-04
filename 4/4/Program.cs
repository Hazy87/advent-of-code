// See https://aka.ms/new-console-template for more information
using _4;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


Console.WriteLine("Hello, World!");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IFileService, FileService>()
        .AddTransient<IProcessRunner, ProcessRunner>()
        .AddTransient<IBoardCheckingService, BoardCheckingService>()
        .AddTransient<IBoardMakerService, BoardMakerService>()
        ).Build();
var runner = host.Services.GetService<IProcessRunner>();
await runner.Run();


