public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IFishProcessService _fishProcessService;

    public ProcessRunner(IInputService inputService, IFishProcessService fishProcessService)
    {
        _inputService = inputService;
        _fishProcessService = fishProcessService;
    }

    public async Task Run(int days)
    {
        var originalFish = (await _inputService.GetLaternFish()).ToList();
        for (var i = 0; i <= days-1; i++)
        {
            _fishProcessService.Process(originalFish);
            Console.WriteLine($"Calculated day {i} so far got {originalFish.Count}");
        }
        Console.WriteLine(string.Join(",", originalFish.Select(x => x.SpawnTimer)));
        Console.WriteLine($"Total {originalFish.Count}");
    }
}