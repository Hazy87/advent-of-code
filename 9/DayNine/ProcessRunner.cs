using System.Collections.Concurrent;
using DayNine.Interfaces;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IRiskPointFinderService _riskPointFinderService;

    public ProcessRunner(IInputService inputService, IRiskPointFinderService riskPointFinderService)
    {
        _inputService = inputService;
        _riskPointFinderService = riskPointFinderService;
    }

    public async Task Run()
    {
        var lines = (await _inputService.GetLines()).ToList();
        var basinSizes = _riskPointFinderService.BasinFinder(lines);
        var starter = 1;
        basinSizes.ForEach(x => starter = x * starter);

        Console.WriteLine($"done {starter}");
    }
}