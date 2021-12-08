using System.Collections.Concurrent;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly ICounterService _counterService;

    public ProcessRunner(IInputService inputService, ICounterService counterService)
    {
        _inputService = inputService;
        _counterService = counterService;
    }

    public async Task Run()
    {
        var input = await _inputService.GetInput();
        
        var counter = _counterService.Count(input);
        Console.WriteLine($"Counter is {counter}");
    }
}