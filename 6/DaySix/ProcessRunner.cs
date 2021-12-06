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
        var count = 0;
        var oldFishCounter = 0;
        /*foreach (var lanternFish in originalFish)
        {
            count += NewMethod(days, new List<LanternFish>(){ lanternFish }, oldFishCounter, originalFish.Count);
            oldFishCounter++;
        }*/

        var fishCounter = originalFish.Count;
        Parallel.ForEach(originalFish, new ParallelOptions { MaxDegreeOfParallelism = 24 }, lanternFish =>
        {
            count++;
            Console.WriteLine($"Processing {count} of {fishCounter} parents");
            var localFishCounter = _fishProcessService.CountFishChildren(lanternFish, days);
            Interlocked.Add(ref fishCounter, localFishCounter);
            Console.WriteLine($"Finished processing {count} of {fishCounter} parents");

        });
        Console.WriteLine($"New {fishCounter}");
        Console.WriteLine($"Total {count}");

    }

    private int NewMethod(int days, List<LanternFish> originalFish, int counter, int fishCounter)
    {
        for (var i = 0; i <= days - 1; i++)
        {
            _fishProcessService.Process(originalFish);
            //Console.WriteLine($"Calculated day {i} so far got {originalFish.Count} for fish {counter}/{fishCounter}");
            Console.WriteLine(string.Join(",", originalFish.Select(x => x.SpawnTimer)));

        }

        Console.WriteLine(string.Join(",", originalFish.Select(x => x.SpawnTimer)));
        return originalFish.Count;
    }
}