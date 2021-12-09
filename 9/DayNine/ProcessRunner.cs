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
        var totalRiskPoints = 0;
        for (var i = 0; i < lines.Count()-2; i++)
        {
            var riskPoints = _riskPointFinderService.FindRiskPoints(lines[i], lines[i+1], lines[i+2]);
            totalRiskPoints += riskPoints.Sum();
        }

        Console.WriteLine($"done {totalRiskPoints}");
    }
}