namespace Template.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;

    public ProcessRunner(IInputService inputService)
    {
        _inputService = inputService;
    }

    public async Task Run()
    {
        await _inputService.GetLines();
        Console.WriteLine($"done");
    }
}