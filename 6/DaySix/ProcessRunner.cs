using System.Collections.Concurrent;

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
        var concurrentDictionary = new ConcurrentDictionary<int, long>();
        foreach (var fish in originalFish.DistinctBy(x => x))
            concurrentDictionary[fish] =  0;
        var fishCounter = originalFish.Count;
        /*foreach (var concurrentDictionaryKey in concurrentDictionary.Keys)
        {

            var localFishCounter = _fishProcessService.CountFishChildren(concurrentDictionaryKey, days);
            concurrentDictionary[concurrentDictionaryKey] = localFishCounter + 1;
        }*/
        Parallel.ForEach(concurrentDictionary.Keys, new ParallelOptions { MaxDegreeOfParallelism = 5 }, lanternFish =>
        {
            var localFishCounter = _fishProcessService.CountFishChildren(lanternFish, days);
            concurrentDictionary[lanternFish] = localFishCounter + 1;
        });
        
        Console.WriteLine($"Really New {originalFish.Select(x => concurrentDictionary[x]).Sum()}");
    }
}